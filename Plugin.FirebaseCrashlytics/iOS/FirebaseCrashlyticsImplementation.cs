using System;
using Firebase.Crashlytics;
using Foundation;
using System.Linq;
using System.Threading.Tasks;

namespace Plugin.FirebaseCrashlytics
{
    public class FirebaseCrashlyticsImplementation : IFirebaseCrashlytics
    {
        private bool _isUncaughtExceptionHandled;

        public bool DidCrashOnPreviousExecution =>
            Crashlytics.SharedInstance.DidCrashDuringPreviousExecution;

        public void SetCustomKey(string key, bool value)
        {
            Crashlytics.SharedInstance.SetCustomValue(new NSNumber(value), key);
        }

        public void SetCustomKey(string key, int value)
        {
            Crashlytics.SharedInstance.SetCustomValue(new NSNumber(value), key);
        }

        public void SetCustomKey(string key, long value)
        {
            Crashlytics.SharedInstance.SetCustomValue(new NSNumber(value), key);
        }

        public void SetCustomKey(string key, float value)
        {
            Crashlytics.SharedInstance.SetCustomValue(new NSNumber(value), key);
        }

        public void SetCustomKey(string key, double value)
        {
            Crashlytics.SharedInstance.SetCustomValue(new NSNumber(value), key);
        }

        public void SetCustomKey(string key, string value)
        {
            Crashlytics.SharedInstance.SetCustomValue(new NSString(value), key);
        }

        public void SetUserId(string identifier)
        {
            Crashlytics.SharedInstance.SetUserId(identifier);
        }

        public void RecordException(Exception exception)
        {
            if (exception == null) throw new ArgumentNullException(nameof(exception));

            var exceptionModel = new ExceptionModel(exception.GetType().ToString(), exception.Message)
            {
                StackTrace = StackTraceParser.Parse(exception).Select(frame =>
                    new Firebase.Crashlytics.StackFrame(
                        string.IsNullOrEmpty(frame.MethodName) ? frame.ClassName : $"{frame.ClassName}.{frame.MethodName}",
                        frame.FileName,
                        frame.LineNumber)).ToArray()
            };

            Crashlytics.SharedInstance.RecordExceptionModel(exceptionModel);
        }

        public void Log(string message)
        {
            Crashlytics.SharedInstance.Log(message);
        }

        public void SetCrashlyticsCollectionEnabled(bool enabled)
        {
            Crashlytics.SharedInstance.SetCrashlyticsCollectionEnabled(enabled);
        }

        public Task<bool> CheckForUnsentReportsAsync()
        {
            return Crashlytics.SharedInstance.CheckForUnsentReportsAsync();
        }

        public void SendUnsentReports()
        {
            Crashlytics.SharedInstance.SendUnsentReports();
        }

        public void DeleteUnsentReports()
        {
            Crashlytics.SharedInstance.DeleteUnsentReports();
        }

        public void HandleUncaughtException(bool shouldThrowFormattedException = true)
        {
            if (!_isUncaughtExceptionHandled)
            {
                _isUncaughtExceptionHandled = true;

                AppDomain.CurrentDomain.UnhandledException += (s, e) =>
                {
                    if (e.ExceptionObject is Exception exception)
                    {
                        RecordException(exception);
                    }
                };
            }
        }
    }
}

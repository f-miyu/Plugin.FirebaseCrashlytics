using System;
using System.Threading.Tasks;
using Android.Gms.Extensions;
using Android.Runtime;
using Java.Lang;

namespace Plugin.FirebaseCrashlytics
{
    public class FirebaseCrashlyticsImplementation : IFirebaseCrashlytics
    {
        private EventHandler<RaiseThrowableEventArgs>? _handler;

        public bool DidCrashOnPreviousExecution =>
            Firebase.Crashlytics.FirebaseCrashlytics.Instance.DidCrashOnPreviousExecution();

        public void SetCustomKey(string key, bool value)
        {
            Firebase.Crashlytics.FirebaseCrashlytics.Instance.SetCustomKey(key, value);
        }

        public void SetCustomKey(string key, int value)
        {
            Firebase.Crashlytics.FirebaseCrashlytics.Instance.SetCustomKey(key, value);
        }

        public void SetCustomKey(string key, long value)
        {
            Firebase.Crashlytics.FirebaseCrashlytics.Instance.SetCustomKey(key, value);
        }

        public void SetCustomKey(string key, float value)
        {
            Firebase.Crashlytics.FirebaseCrashlytics.Instance.SetCustomKey(key, value);
        }

        public void SetCustomKey(string key, double value)
        {
            Firebase.Crashlytics.FirebaseCrashlytics.Instance.SetCustomKey(key, value);
        }

        public void SetCustomKey(string key, string value)
        {
            Firebase.Crashlytics.FirebaseCrashlytics.Instance.SetCustomKey(key, value);
        }

        public void SetUserId(string identifier)
        {
            Firebase.Crashlytics.FirebaseCrashlytics.Instance.SetUserId(identifier);
        }

        public void RecordException(System.Exception exception)
        {
            Firebase.Crashlytics.FirebaseCrashlytics.Instance.RecordException(CrashlyticsException.Create(exception));
        }

        public void Log(string message)
        {
            Firebase.Crashlytics.FirebaseCrashlytics.Instance.Log(message);
        }

        public void SetCrashlyticsCollectionEnabled(bool enabled)
        {
            Firebase.Crashlytics.FirebaseCrashlytics.Instance.SetCrashlyticsCollectionEnabled(enabled);
        }

        public async Task<bool> CheckForUnsentReportsAsync()
        {
            var result = await Firebase.Crashlytics.FirebaseCrashlytics.Instance.CheckForUnsentReports()
                .AsAsync<Java.Lang.Boolean>()
                .ConfigureAwait(false);

            return (bool)result;
        }

        public void SendUnsentReports()
        {
            Firebase.Crashlytics.FirebaseCrashlytics.Instance.SendUnsentReports();
        }

        public void DeleteUnsentReports()
        {
            Firebase.Crashlytics.FirebaseCrashlytics.Instance.DeleteUnsentReports();
        }

        public void HandleUncaughtException(bool shouldThrowFormattedException = true)
        {
            if (_handler != null)
            {
                AndroidEnvironment.UnhandledExceptionRaiser -= _handler;
            }

            _handler = (s, e) =>
            {
                if (shouldThrowFormattedException && Thread.DefaultUncaughtExceptionHandler != null)
                {
                    Thread.DefaultUncaughtExceptionHandler.UncaughtException(Thread.CurrentThread(), CrashlyticsException.Create(e.Exception));
                }
                else
                {
                    RecordException(e.Exception);
                }
            };

            AndroidEnvironment.UnhandledExceptionRaiser += _handler;
        }
    }
}

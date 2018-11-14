using System;
using Firebase.Crashlytics;
using Foundation;
using System.Collections.Generic;
using System.Linq;

namespace Plugin.FirebaseCrashlytics
{
    public class FirebaseCrashlyticsImplementation : IFirebaseCrashlytics
    {
        public void Crash()
        {
            Crashlytics.SharedInstance.Crash();
        }

        public void SetBool(string key, bool value)
        {
            Crashlytics.SharedInstance.SetValue(value, key);
        }

        public void SetInt(string key, int value)
        {
            Crashlytics.SharedInstance.SetValue(value, key);
        }

        public void SetLong(string key, long value)
        {
            Crashlytics.SharedInstance.SetValue(new NSNumber(value), key);
        }

        public void SetFloat(string key, float value)
        {
            Crashlytics.SharedInstance.SetValue(value, key);
        }

        public void SetDouble(string key, double value)
        {
            Crashlytics.SharedInstance.SetValue(new NSNumber(value), key);
        }

        public void SetString(string key, string value)
        {
            Crashlytics.SharedInstance.SetValue(value, key);
        }

        public void SetUserIdentifier(string identifier)
        {
            Crashlytics.SharedInstance.SetUserIdentifier(identifier);
        }

        public void SetUserName(string name)
        {
            Crashlytics.SharedInstance.SetUserName(name);
        }

        public void SetUserEmail(string email)
        {
            Crashlytics.SharedInstance.SetUserEmail(email);
        }

        public void LogException(Exception exception)
        {
            var userInfo = new Dictionary<object, object>
            {
                [NSError.LocalizedDescriptionKey] = exception.Message,
                ["StackTrace"] = exception.StackTrace
            };

            var error = new NSError(new NSString(exception.GetType().FullName),
                                    -1,
                                    NSDictionary.FromObjectsAndKeys(userInfo.Values.ToArray(), userInfo.Keys.ToArray(), userInfo.Count));

            Crashlytics.SharedInstance.RecordError(error);
        }

        public void Log(string message)
        {
            Logging.Log(message);
        }
    }
}

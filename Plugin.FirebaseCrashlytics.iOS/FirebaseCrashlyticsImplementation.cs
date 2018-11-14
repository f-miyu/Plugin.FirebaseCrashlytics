using System;
using Firebase.Crashlytics;
using Foundation;

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

        public void SetFloat(string key, float value)
        {
            Crashlytics.SharedInstance.SetValue(value, key);
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
            Crashlytics.SharedInstance.RecordError(new NSError(new NSString(exception.GetType().Name), -1));
        }

        public void Log(string message)
        {
            Logging.Log(message);
        }
    }
}

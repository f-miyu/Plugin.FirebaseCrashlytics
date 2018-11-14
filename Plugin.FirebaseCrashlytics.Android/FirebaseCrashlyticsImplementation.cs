using System;

namespace Plugin.FirebaseCrashlytics
{
    public class FirebaseCrashlyticsImplementation : IFirebaseCrashlytics
    {
        public void Crash()
        {
            Crashlytics.Crashlytics.Instance.Crash();
        }

        public void SetBool(string key, bool value)
        {
            Crashlytics.Crashlytics.SetBool(key, value);
        }

        public void SetInt(string key, int value)
        {
            Crashlytics.Crashlytics.SetInt(key, value);
        }

        public void SetFloat(string key, float value)
        {
            Crashlytics.Crashlytics.SetFloat(key, value);
        }

        public void SetString(string key, string value)
        {
            Crashlytics.Crashlytics.SetString(key, value);
        }

        public void SetUserIdentifier(string identifier)
        {
            Crashlytics.Crashlytics.SetUserIdentifier(identifier);
        }

        public void SetUserName(string name)
        {
            Crashlytics.Crashlytics.SetUserName(name);
        }

        public void SetUserEmail(string email)
        {
            Crashlytics.Crashlytics.SetUserEmail(email);
        }

        public void LogException(Exception exception)
        {
            Crashlytics.Crashlytics.LogException(new Java.Lang.Exception(exception.Message));
        }

        public void Log(string message)
        {
            Crashlytics.Crashlytics.Log(message);
        }
    }
}

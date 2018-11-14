using System;
namespace Plugin.FirebaseCrashlytics
{
    public interface IFirebaseCrashlytics
    {
        void Crash();
        void SetBool(string key, bool value);
        void SetInt(string key, int value);
        void SetFloat(string key, float value);
        void SetString(string key, string value);
        void SetUserIdentifier(string identifier);
        void SetUserName(string name);
        void SetUserEmail(string email);
        void LogException(Exception exception);
        void Log(string message);
    }
}

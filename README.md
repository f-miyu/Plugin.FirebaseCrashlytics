# Plugin.FirebaseCrashlytics

A cross platform plugin for Firebase Crashlytics. 
A wrapper for [Xamarin.Firebase.iOS.Crashlytics](https://www.nuget.org/packages/Xamarin.Firebase.iOS.Crashlytics/) 
and the binding library of firebase-crashlytics.

## Setup
Install Nuget package to each projects.

[Plugin.FirebaseCrashlytics](https://www.nuget.org/packages/Plugin.FirebaseCrashlytics/) [![NuGet](https://img.shields.io/nuget/vpre/Plugin.FirebaseCrashlytics.svg?label=NuGet)](https://www.nuget.org/packages/Plugin.FirebaseCrashlytics/)

### iOS
* Add GoogleService-Info.plist to iOS project. Select BundleResource as build action.
* Initialize as follows in AppDelegate. 
```C#
Firebase.Core.App.Configure();
```
* Refer to [Xamarin.Firebase.iOS.Crashlytics](https://github.com/xamarin/GoogleApisForiOSComponents/tree/master/source/Firebase/Crashlytics) for more information.

### Android
* Add google-services.json to Android project. Select GoogleServicesJson as build action. (If you can't select GoogleServicesJson, reload this android project.)
* Target framework version needs to be Android 10.0.
* Create a string resource with the name `com.crashlytics.android.build_id`. 
The value can be whatever you want to uniquely identify a particular build with.
```xml
<string name="com.crashlytics.android.build_id">1.0</string>
```

## Usage

### Add custom logs
```C#
CrossFirebaseCrashlytics.Current.Log("hoge")
```

### Add custom keys
```C#
// bool
CrossFirebaseCrashlytics.Current.SetCustomKey(key, true);

// int
CrossFirebaseCrashlytics.Current.SetCustomKey(key, 1);

// long
CrossFirebaseCrashlytics.Current.SetCustomKey(key, 1L);

// float
CrossFirebaseCrashlytics.Current.SetCustomKey(key, 1.0f);

// double
CrossFirebaseCrashlytics.Current.SetCustomKey(key, 1.0);

// string
CrossFirebaseCrashlytics.Current.SetCustomKey(key, "foo");
```

### Set user identifier
```C#
CrossFirebaseCrashlytics.Current.SetUserIdentifier("id");
```

### Log non-fatal exceptions
```C#
CrossFirebaseCrashlytics.Current.RecordException(exception);
```

### Handle uncaught exception
you can handle uncaught exceptions for sending the stack trace to Crashlytics. If the argument `shouldThrowFormattedException` is true, it rethrows the formatted exception (`CrashlyticsException`), otherwise it calls `RecordException` on Android. It calls `RecordException` regardless of the argument on iOS.

```C#
CrossFirebaseCrashlytics.Current.HandleUncaughtException();
```

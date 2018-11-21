# Plugin.FirebaseCrashlytics

A cross platform plugin for Firebase Crashlytics. 
A wrapper for [Xamarin.Firebase.iOS.Crashlytics](https://www.nuget.org/packages/Xamarin.Firebase.iOS.Crashlytics/) 
and [Xamarin.Android.Crashlytics](https://www.nuget.org/packages/Xamarin.Android.Crashlytics/).

## Setup
Install Nuget package to each projects.

[Plugin.FirebaseCrashlytics](https://www.nuget.org/packages/Plugin.FirebaseCrashlytics/) [![NuGet](https://img.shields.io/nuget/v/Plugin.FirebaseCrashlytics.svg?label=NuGet)](https://www.nuget.org/packages/Plugin.FirebaseCrashlytics/)

### iOS
* Add GoogleService-Info.plist to iOS project. Select BundleResource as build action.
* Initialize as follows in AppDelegate. 
```C#
Firebase.Core.App.Configure();
Firebase.Crashlytics.Crashlytics.Configure();
```

### Android
* Add google-services.json to Android project. Select GoogleServicesJson as build action. (If you can't select GoogleServicesJson, reload this android project.)
* Initialize as follows in MainActivity.
```C#
Fabric.Fabric.With(this, new Crashlytics.Crashlytics());
```
* Create a string resource with the name `com.crashlytics.android.build_id`. 
The value can be whatever you want to uniquely identify a particular build with.
```xml
<string name="com.crashlytics.android.build_id">1.0</string>
```

* Optionally, you can format unhandled exceptions for Crashlytics.
```C#
Crashlytics.Crashlytics.HandleManagedExceptions();
```

## Usage
### Force a crash
```C#
CrossFirebaseCrashlytics.Current.Crash()
```

### Add custom logs
```C#
CrossFirebaseCrashlytics.Current.Log("hoge")
```

### Add custom keys
```C#
// bool
CrossFirebaseCrashlytics.Current.SetBool(key, true);

// int
CrossFirebaseCrashlytics.Current.SetInt(key, 1);

// long
CrossFirebaseCrashlytics.Current.SetLong(key, 1L);

// float
CrossFirebaseCrashlytics.Current.SetFloat(key, 1.0f);

// double
CrossFirebaseCrashlytics.Current.SetDouble(key, 1.0);

// string
CrossFirebaseCrashlytics.Current.SetString(key, "foo");
```

### Set user information
```C#
// ID
CrossFirebaseCrashlytics.Current.SetUserIdentifier("id");

// Name
CrossFirebaseCrashlytics.Current.SetUserName("name");

// E-mail
CrossFirebaseCrashlytics.Current.SetUserEmail("user@mail.com");
```

### Log non-fatal exceptions
```C#
CrossFirebaseCrashlytics.Current.LogException(exception);
```

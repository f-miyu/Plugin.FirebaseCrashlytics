using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Plugin.FirebaseCrashlytics.Sample.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ICommand CrashCommand { get; }
        public ICommand ExceptionCommand { get; }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";

            CrashCommand = new DelegateCommand(() =>
            {
                CrossFirebaseCrashlytics.Current.SetInt("value", 100);
                CrossFirebaseCrashlytics.Current.Log("test");
                CrossFirebaseCrashlytics.Current.SetUserIdentifier("12345");
                CrossFirebaseCrashlytics.Current.SetUserName("name");

                CrossFirebaseCrashlytics.Current.Crash();
            });

            ExceptionCommand = new DelegateCommand(() =>
            {
                try
                {
                    throw new Exception("exception occured");
                }
                catch (Exception e)
                {
                    CrossFirebaseCrashlytics.Current.LogException(e);
                }
            });
        }
    }
}

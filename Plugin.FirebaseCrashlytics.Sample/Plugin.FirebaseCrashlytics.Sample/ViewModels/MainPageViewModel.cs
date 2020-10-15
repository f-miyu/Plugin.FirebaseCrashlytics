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
                CrossFirebaseCrashlytics.Current.SetCustomKey("value", 100);
                CrossFirebaseCrashlytics.Current.Log("test");
                CrossFirebaseCrashlytics.Current.SetUserId("12345");

                ThrowException("crash!");
            });

            ExceptionCommand = new DelegateCommand(() =>
            {
                try
                {
                    ThrowException("exception occured");
                }
                catch (Exception e)
                {
                    CrossFirebaseCrashlytics.Current.RecordException(e);
                }
            });
        }

        private void ThrowException(string message)
        {
            throw new Exception(message);
        }
    }
}

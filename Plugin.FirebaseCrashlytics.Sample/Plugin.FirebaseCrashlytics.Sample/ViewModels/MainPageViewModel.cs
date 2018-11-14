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

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";

            CrashCommand = new DelegateCommand(() =>
            {
                CrossFirebaseCrashlytics.Current.SetInt("aaa", 1);
                CrossFirebaseCrashlytics.Current.SetLong("bbb", long.MaxValue);
                CrossFirebaseCrashlytics.Current.SetFloat("ccc", 1.5f);
                CrossFirebaseCrashlytics.Current.SetDouble("ddd", double.MaxValue);
                CrossFirebaseCrashlytics.Current.SetBool("eee", true);
                CrossFirebaseCrashlytics.Current.SetString("fff", "test");

                CrossFirebaseCrashlytics.Current.SetUserIdentifier("id123");

                CrossFirebaseCrashlytics.Current.Log("test");

                try
                {
                    throw new NullReferenceException();
                }
                catch (Exception e)
                {
                    CrossFirebaseCrashlytics.Current.LogException(e);
                }

                CrossFirebaseCrashlytics.Current.Crash();
            });
        }
    }
}

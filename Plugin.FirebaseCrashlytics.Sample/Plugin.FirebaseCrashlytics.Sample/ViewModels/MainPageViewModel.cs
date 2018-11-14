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
                CrossFirebaseCrashlytics.Current.Crash();
            });
        }
    }
}

using System;
using System.Windows.Input;
using ProjectMTG.App.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using ProjectMTG.App.Helpers;
using ProjectMTG.App.Services;
using ProjectMTG.Model;

namespace ProjectMTG.App.Views
{
    // TODO WTS: Change the icons and titles for all NavigationViewItems in ShellPage.xaml.
    public sealed partial class ShellPage : Page
    {
        public ShellViewModel ViewModel { get; } = new ShellViewModel();

        public ICommand StartCommand { get; set; }

        public ShellPage()
        {
            InitializeComponent();
            DataContext = ViewModel;
            ViewModel.Initialize(shellFrame, navigationView, KeyboardAccelerators);

            StartCommand = new RelayCommand(OnStart);
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            User x = (User) e.Parameter;
            ShellViewModel.LoggedInUser = x;
        }

        private void OnStart()
        {
            NavigationService.Navigate<Views.ShellPage>();
            
            NavigationService.Navigate<Views.MainPage>();
        }
    }
}

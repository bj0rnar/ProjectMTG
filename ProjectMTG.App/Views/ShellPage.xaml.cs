using System;
using System.Windows.Input;
using ProjectMTG.App.ViewModels;

using Windows.UI.Xaml.Controls;
using ProjectMTG.App.Helpers;
using ProjectMTG.App.Services;

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

        private void OnStart()
        {
            //Navigating to a ShellPage, this will replaces NavigationService frame for an inner frame to change navigation handling.
            NavigationService.Navigate<Views.ShellPage>();

            //Navigating now to a HomePage, this will be the first navigation on a NavigationPane menu
            NavigationService.Navigate<Views.MainPage>();
        }
    }
}

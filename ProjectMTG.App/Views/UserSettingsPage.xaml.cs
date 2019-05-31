using System;

using ProjectMTG.App.ViewModels;

using Windows.UI.Xaml.Controls;

namespace ProjectMTG.App.Views
{
    public sealed partial class UserSettingsPage : Page
    {
        public UserSettingsViewModel ViewModel { get; } = new UserSettingsViewModel();

        public UserSettingsPage()
        {
            InitializeComponent();
        }
    }
}

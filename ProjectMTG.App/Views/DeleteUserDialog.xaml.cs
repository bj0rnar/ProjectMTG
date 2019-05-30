using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjectMTG.App.Views
{
    public enum UserDeleteChoice
    {
        Delete,
        Cancel,
        Nothing
    }


    public sealed partial class DeleteUserDialog : ContentDialog
    {
        public UserDeleteChoice UserDelete { get; set; }

        public DeleteUserDialog()
        {
            this.InitializeComponent();
            this.UserDelete = UserDeleteChoice.Nothing;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.UserDelete = UserDeleteChoice.Delete;
            deleteuserdialog.Hide();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.UserDelete = UserDeleteChoice.Cancel;
            deleteuserdialog.Hide();
        }
    }
}

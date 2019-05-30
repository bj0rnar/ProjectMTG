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
    public enum DeletionChoices
    {
        Keep,
        Delete,
        Nothing
    }

    public sealed partial class EmptyDeckWarning : ContentDialog
    {
        public DeletionChoices DeleteChoice;

        public EmptyDeckWarning()
        {
            this.InitializeComponent();
            this.DeleteChoice = DeletionChoices.Nothing;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.DeleteChoice = DeletionChoices.Keep;
            deletedialog.Hide();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.DeleteChoice = DeletionChoices.Delete;
            deletedialog.Hide();
        }
    }
}

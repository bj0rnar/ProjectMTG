using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using ProjectMTG.Model;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjectMTG.App.Views
{
    public enum UserChoice
    {
    Create,
    Edit,
    Nothing
    }

    public sealed partial class ContentDialog1 : ContentDialog
    {

        private ObservableCollection<Deck> _deckList { get; set; }
        private Deck _selectedDeck;
        public UserChoice choice { get; set; }

        public ContentDialog1(ObservableCollection<Deck> userDeckList)
        {
            this.InitializeComponent();
            _deckList = userDeckList;
            _selectedDeck = null;
            this.choice = UserChoice.Nothing;

        }

        private void ContentDialog1_OnPrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.choice = UserChoice.Create;
            dialog.Hide();
        }

        private void ContentDialog1_OnSecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.choice = UserChoice.Edit;
            dialog.Content = _selectedDeck;
            dialog.Hide();

        }

        private void ContentDialogDecklist_OnItemClick(object sender, ItemClickEventArgs e)
        {
            _selectedDeck = (Deck) e.ClickedItem;
        }

     
        
    }
}

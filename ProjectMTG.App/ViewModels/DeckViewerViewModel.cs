using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ProjectMTG.App.Helpers;
using ProjectMTG.Model;
using Remotion.Linq.Clauses;

namespace ProjectMTG.App.ViewModels
{
    public class DeckViewerViewModel : Observable
    {
        //Static user from MainViewModel, remove later
        private User User = MainViewModel.DemoUser;

        private ObservableCollection<Deck> ObservableDeckList = new ObservableCollection<Deck>();
        public ObservableCollection<Deck> GetObservableDeckList => this.ObservableDeckList;

        public DeckViewerViewModel()
        {
            Debug.WriteLine(User.UserName);

            foreach (Deck deck in User.Decks)
            {
                ObservableDeckList.Add(deck);
            }
        }

        
    }
}

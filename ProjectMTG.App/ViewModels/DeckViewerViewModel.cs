using System;
using System.Diagnostics;
using ProjectMTG.App.Helpers;
using ProjectMTG.Model;

namespace ProjectMTG.App.ViewModels
{
    public class DeckViewerViewModel : Observable
    {
        private User User = MainViewModel.DemoUser;

        public DeckViewerViewModel()
        {
            Debug.WriteLine(User.UserName);
        }
    }
}

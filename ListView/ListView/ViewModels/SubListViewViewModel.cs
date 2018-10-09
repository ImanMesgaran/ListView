using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace ListView.ViewModels
{
	public class SubListViewViewModel : ViewModelBase
	{
	    private Chapter _itemChapter;
        public Chapter ItemChapter
        {
            get { return _itemChapter; }
            set { SetProperty(ref _itemChapter, value); }
        }

        private ObservableCollection<Card> _cards;
        public ObservableCollection<Card> Cards
        {
            get { return _cards; }
            set { SetProperty(ref _cards, value); }
        }

        public SubListViewViewModel(INavigationService navigationService) : base(navigationService)
        {
           Debug.WriteLine("********************");
        }

	    public override void OnNavigatingTo(NavigationParameters parameters)
	    {
	        if (parameters.ContainsKey("Item"))
	        {
	            ItemChapter = (Chapter)parameters["Item"];

	            Cards = new ObservableCollection<Card>(ItemChapter.Cards);
	        }

	    }
	}
}

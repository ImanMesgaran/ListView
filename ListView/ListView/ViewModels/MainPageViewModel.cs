﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListView.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private DelegateCommand _gotoMainListPageCommand;
        public DelegateCommand GotoMainListPageCommand =>
            _gotoMainListPageCommand ?? (_gotoMainListPageCommand = new DelegateCommand(ExecuteGotoMainListPageCommand));

        async void ExecuteGotoMainListPageCommand()
        {
            await NavigationService.NavigateAsync("MainListView");
        }

        private DelegateCommand _gotoNewsPageCommand;
        public DelegateCommand GotoNewsPageCommand =>
            _gotoNewsPageCommand ?? (_gotoNewsPageCommand = new DelegateCommand(ExecuteGotoNewsPageCommand));

        async void ExecuteGotoNewsPageCommand()
        {
            await NavigationService.NavigateAsync("NewsPage");
        }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
        }
    }
}

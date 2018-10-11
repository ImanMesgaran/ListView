using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using MvvmHelpers;
using Prism.Navigation;
using Xamarin.Forms;

namespace ListView.ViewModels
{
	public class NewsPageViewModel : ViewModelBase
    {
	    public ObservableRangeCollection<Grouping<string, NewsItems>> NewsGrouped { get; set; }
	    public ObservableRangeCollection<Grouping<KeyCategory, NewsItems>> NewsGroupedWithSpan { get; set; }

        public NewsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            NewsGrouped = new ObservableRangeCollection<Grouping<string, NewsItems>>();
            NewsGroupedWithSpan = new ObservableRangeCollection<Grouping<KeyCategory, NewsItems>>();

            var items = GetHomeItems();

            //var pps = from item in items
            //          orderby item.IsRead
            //          group item by item.IsRead
            //          into groupCat
            //          select new Grouping<string, NewsItems>(groupCat.Key ? AppResources.ReadNewsText : AppResources.UnreadNewsesText, groupCat);

            var pps = from item in items
                orderby item.IsRead
                group item by item.IsRead
                into groupCat
                    //select new Grouping<KeyCategory, NewsItems>(groupCat.Key ? AppResources.ReadNewsText : AppResources.UnreadNewsesText, groupCat);
                select new Grouping<KeyCategory, NewsItems>(new KeyCategory((groupCat.Key ? "Read News" : "UNRead News"), (groupCat.Key ? "\uf058" : "\uf06a"),(groupCat.Key ? Color.Green : Color.DarkOrange)), groupCat);

            //NewsGrouped.ReplaceRange(pps);
            NewsGroupedWithSpan.ReplaceRange(pps);


        }

        private List<NewsItems> GetHomeItems()
        {
            var list = new List<NewsItems>();

            //////
            list.Add(new NewsItems()
            {
                Name = "item 1",
                //Category = AppResources.UnreadNewsesText,
                Description = "Description 1",
                IsRead = false
            });
            list.Add(new NewsItems()
            {
                Name = "item 2",
                //Category = AppResources.UnreadNewsesText,
                Description = "Description 2",
                IsRead = false
            });
            list.Add(new NewsItems()
            {
                Name = "item 3",
                //Category = AppResources.UnreadNewsesText,
                Description = "Description 3",
                IsRead = false
            });
            list.Add(new NewsItems()
            {
                Name = "item 4",
                //Category = AppResources.UnreadNewsesText,
                Description = "Description 4",
                IsRead = false
            });
            list.Add(new NewsItems()
            {
                Name = "item 5",
                //Category = AppResources.UnreadNewsesText,
                Description = "Description 5",
                IsRead = false
            });

            //////
            list.Add(new NewsItems()
            {
                Name = "item 1",
                //Category = AppResources.ReadNewsText,
                Description = "Description 1",
                IsRead = true
            });
            list.Add(new NewsItems()
            {
                Name = "item 2",
                //Category = AppResources.ReadNewsText,
                Description = "Description 2",
                IsRead = true
            });

            return list;
        }

        public class NewsItems
        {
            //public string Category { get; set; }
            public bool IsRead { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }

        }
    }

    public class KeyCategory
    {
        public string Key { get; set; }
        public string Icon { get; set; }

        public Color Color { get; set; }

        public KeyCategory(string key, string icon,Color color)
        {
            Key = key;
            Icon = icon;
            Color = color;
        }
    }
}

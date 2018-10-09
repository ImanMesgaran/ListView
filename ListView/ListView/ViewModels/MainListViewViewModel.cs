using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using MvvmHelpers;

namespace ListView.ViewModels
{
    public class Grouping<K, T> : ObservableCollection<T>
    {
        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value>The key.</value>
        public K Key { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Grouping{K, T}"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="items">The items.</param>
        public Grouping(K key, IEnumerable<T> items)
        {
            Key = key;
            foreach (var item in items)
            {
                this.Items.Add(item);
            }
        }
    }

    public class MainListViewViewModel : ViewModelBase
    {
        private DelegateCommand<Chapter> _itemTappedCommand;
        public DelegateCommand<Chapter> ItemTappedCommand =>
            _itemTappedCommand ?? (_itemTappedCommand = new DelegateCommand<Chapter>(ExecuteItemTappedCommand));

        async void ExecuteItemTappedCommand(Chapter parameter)
        {
            var navParameter = new NavigationParameters();
            navParameter.Add("Item", parameter);
            await NavigationService.NavigateAsync("SubListView", navParameter);
        }

        public List<Book> Books = new List<Book>();

        public ObservableRangeCollection<Grouping<string, Chapter>> MockBooks { get; set; }

        public MainListViewViewModel(INavigationService navigationService) : base(navigationService)
        {
            MockBooks = new ObservableRangeCollection<Grouping<string, Chapter>>();
            
            Books.Add(new Book("Book 1", new Chapter[]{new Chapter("Chapter 1",new Card[]{new Card("Card 1"),new Card("Card 2"), new Card("Card 3")}), new Chapter("Chapter 2", new Card[]{new Card("Card 1"), new Card("Card2") }), new Chapter("Chapter 3", new Card[]{new Card("Card 1"), new Card("Card2"), new Card("Card 3"),   }), new Chapter("Chapter 4", new Card[]{new Card("Card 1"), new Card("Card 2"), new Card("Card 3"), }),  }));
            Books.Add(new Book("Book 2", new Chapter[]{new Chapter("Chapter 1", new Card[]{new Card("Card 1"),new Card("Card 2"), new Card("Card 3")}), new Chapter("Chapter 2", new Card[]{new Card("Card 1"), new Card("Card2") }), new Chapter("Chapter 3", new Card[]{new Card("Card 1"), new Card("Card2"), new Card("Card 3"),   }), new Chapter("Chapter 4", new Card[]{new Card("Card 1"), new Card("Card 2"), new Card("Card 3"), }),  }));

            var mockBooks = from book in Books
                orderby book.Name
                from chapter in book.Chapters
                group chapter by book.Name
                into bookGroup
                select new Grouping<string, Chapter>(bookGroup.Key, bookGroup);

            MockBooks.ReplaceRange(mockBooks);
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }

    public class Book
    {
        public string Name { get; set; }
        public Chapter[] Chapters { get; set; }

        public Book(string name, Chapter[] chapters)
        {
            Name = name;
            Chapters = chapters;
        }
    }

    public class Chapter
    {
        public string Name { get; set; }
        public Card[] Cards { get; set; }

        public Chapter(string name, Card[] cards)
        {
            Cards = cards;
            Name = name;
        }
    }

    public class Card
    {
        public string Name { get; set; }

        public Card(string name)
        {
            Name = name;
        }
    }
}

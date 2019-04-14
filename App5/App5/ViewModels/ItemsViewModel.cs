using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using App5.Models;
using App5.Views;

namespace App5.ViewModels
{
    public class Command1 : Command
    {
        public Command1(Action execute) : base(execute) { }
        public void Execute(object sender, EventArgs args)
            => Execute(null);
    }
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> FavItems { get; set; } = new ObservableCollection<Item>();
        static System.Collections.Generic.IEnumerable<Item> items;

        public Command LoadItemsCommand { get; set; }
        static public Command LoadItemsCommand1 { get; set; }
        static public Command1 SearchItems { get; set; }
        static public Command1 SearchFavotitesItems { get; set; }



        public ItemsViewModel()
        {
            Title = "Browse";
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            LoadItemsCommand1 = LoadItemsCommand;
            SearchItems = new Command1(async () => await ExecuteSearchItems());
            SearchFavotitesItems = new Command1(async () => await ExecuteSearchFavotitesItems());
        }



        async Task ExecuteLoadItemsCommand()
        {

            if (IsBusy)
                return;

            IsBusy = true;
            Items.Clear();
            FavItems.Clear();
            items = await DataStore.GetItemsAsync(true);
            string Day = "";
            string Day1 = "";
            foreach (var item in items)
            {
                if (item.Day != Day)
                    Items.Add(new Item() { Type = "Day", Day = Day = item.Day });
                Items.Add(item);

                if (AppData.Links.Contains(item.Link))
                {
                    if (item.Day != Day1)
                        FavItems.Add(new Item() { Type = "Day", Day = Day1 = item.Day });
                    FavItems.Add(item);
                }
            }
            IsBusy = false;

        }



        async Task ExecuteSearchItems()
        {

            if (IsBusy)
                return;

            IsBusy = true;
            string SearchQuery = ItemsPage.SearchQuery;
            Items.Clear();
            string Day = "";
            foreach (var item in items)
            {
                if (item.Header.ToLower().
                    Contains(SearchQuery.ToLower()))
                {
                    if (item.Day != Day)
                    {
                        Items.Add(new Item() { Type = "Day", Day = Day = item.Day });
                    }
                    Items.Add(item);
                }
            }
            IsBusy = false;

        }



        async Task ExecuteSearchFavotitesItems()
        {

            if (IsBusy)
                return;

            IsBusy = true;
            string SearchQuery = Favorite.SearchQuery;
            FavItems.Clear();
            string Day = "";
            foreach (var item in items)
            {
                if (AppData.Links.Contains(item.Link) && item.Header.ToLower().
                    Contains(SearchQuery.ToLower()))
                {
                    if (item.Day != Day)
                    {
                        FavItems.Add(new Item() { Type = "Day", Day = Day = item.Day });
                    }
                    FavItems.Add(item);
                }
            }

            IsBusy = false;

        }
    }
}
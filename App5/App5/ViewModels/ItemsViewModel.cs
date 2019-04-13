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
        public Command1(Action execute) : base(execute)
        {}
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
        static public Command LoadFavotitesItemsCommand { get; set; }
        static public Command1 SearchItems { get; set; }
        static public Command1 SearchFavotitesItems { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            LoadItemsCommand1 = LoadItemsCommand;
            LoadFavotitesItemsCommand = new Command(async () => await ExecuteLoadFavotitesItemsCommand());
            SearchItems = new Command1(async () => await ExecuteSearchItems());
            SearchFavotitesItems = new Command1(async () => await ExecuteSearchFavotitesItems());

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {

            if (IsBusy)
                return;

            IsBusy = true;
            Items.Clear();
            FavItems.Clear();
            items = await DataStore.GetItemsAsync(true);
            foreach (var item in items)
            {
                Items.Add(item);
            }
            string Day = "";
            foreach (var item in items)
            {
                if (AppData.Links.Contains(item.Link))
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

        async Task ExecuteLoadFavotitesItemsCommand()
        {

            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                FavItems.Clear();
                string Day = "";
                foreach (var item in items)
                {
                    if (AppData.Links.Contains(item.Link))
                    {
                        if (item.Day != Day)
                        {
                            FavItems.Add(new Item() { Type = "Day", Day = Day = item.Day });
                        }

                        FavItems.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }



        async Task ExecuteSearchItems()
        {

            if (IsBusy)
                return;

            IsBusy = true;
            string q = ItemsPage.q;
            try
            {
                Items.Clear();
                string Day = "";
                foreach (var item in items)
                {
                    if (item.Header.ToLower().Contains(q.ToLower()) && item.Type!="Day")
                    {
                        if (item.Day != Day )
                        {
                            Items.Add(new Item() { Type = "Day", Day = Day = item.Day });
                        }
                        Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }



        async Task ExecuteSearchFavotitesItems()
        {

            if (IsBusy)
                return;

            IsBusy = true;
            string q = Favorite.q;
            try
            {
                FavItems.Clear();
                string Day = "";
                foreach (var item in items)
                {
                    if (AppData.Links.Contains(item.Link) && item.Header.ToLower().Contains(q.ToLower()) && item.Type != "Day")
                    {
                        if (item.Day != Day)
                        {
                            FavItems.Add(new Item() { Type = "Day", Day = Day = item.Day });
                        }
                        FavItems.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
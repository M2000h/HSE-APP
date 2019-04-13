using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using App5.Models;
using App5.Views;

namespace App5.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> FavItems { get; set; } = new ObservableCollection<Item>();
        System.Collections.Generic.IEnumerable<Item> items;

        public Command LoadItemsCommand { get; set; }
        static public Command LoadFavotitesItemsCommand { get; set; }
        
        public ItemsViewModel()
        {
            Title = "Browse";

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            LoadFavotitesItemsCommand = new Command(async () => await ExecuteLoadFavotitesItemsCommand());
            
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

            try
            {
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
                    if (FavotiteLinks.Links.Contains(item.Link))
                    {
                        if (item.Day != Day)
                        {
                            FavItems.Add(new Item() { Type = "Day", Day = Day = item.Day}); 
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
                    if (FavotiteLinks.Links.Contains(item.Link))
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
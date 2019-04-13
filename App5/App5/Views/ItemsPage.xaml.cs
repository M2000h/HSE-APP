using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using App5.Models;
using App5.Views;
using App5.ViewModels;
using App5.Services;
using System.Threading;


namespace App5.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;
        static public string q = "";
        void f(object sender, EventArgs e)
        {
            q = SearchBar.Text;
        }
        void ff(object sender, EventArgs e)
        {
            new MockDataStore(1);
        }
        public ItemsPage()
        {
            
            InitializeComponent();
            BindingContext = viewModel = new ItemsViewModel();
            SearchBar.TextChanged += f;
            SearchBar.TextChanged += ItemsViewModel.SearchItems.Execute;
            ItemsListView.Refreshing += ff;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;
            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void Search_Clicked(object sender, EventArgs e)
        {
            SearchBar.IsVisible = !SearchBar.IsVisible;
            Header.Icon = SearchBar.IsVisible ? "@drawable/cancel.png" : "@drawable/search.png";
            if (SearchBar.IsVisible)
                SearchBar.Focus();
            else
                SearchBar.Text = "";
        }
        string lang = AppData.API_Link;
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0 || lang!= AppData.API_Link)
                viewModel.LoadItemsCommand.Execute(null);
            lang = AppData.API_Link;
        }
    }
}
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App5.Models;
using App5.ViewModels;
namespace App5.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }
        async void Russian_Clicked(object sender, EventArgs args)
        {
            Russian.IsEnabled = false;
            English.IsEnabled = true;
            AppData.API_Link = "https://shakura.dev/hseapi";
            ItemsViewModel.LoadItemsCommand1.Execute(null);
            //Favorite.q = "";
            //ItemsPage.q = " ";
            //ItemsViewModel.SearchItems.Execute(null);
        }
        async void English_Clicked(object sender, EventArgs args)
        {
            English.IsEnabled = false;
            Russian.IsEnabled = true;
            AppData.API_Link = "https://shakura.dev/hseapien";
            ItemsViewModel.LoadItemsCommand1.Execute(null);
            //Favorite.q = "";
            //ItemsPage.q = " ";
            //ItemsViewModel.SearchItems.Execute(null);
        }
    }
}
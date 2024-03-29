﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App5.Models;
using App5.ViewModels;
using App5.Services;

namespace App5.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        static public ItemsViewModel viewModel;
        /// <summary>
        /// search bar query
        /// </summary>
        static public string SearchQuery = "";
        void SearchQueryUpdate(object sender, EventArgs e)
        {
            SearchQuery = SearchBar.Text;
        }
        void reload(object sender, EventArgs e)
        {
            MockDataStore.RealoadData();
        }
        public ItemsPage()
        {
            
            InitializeComponent();
            BindingContext = viewModel = new ItemsViewModel();
            SearchBar.TextChanged += SearchQueryUpdate;
            SearchBar.TextChanged += ItemsViewModel.SearchItems.Execute;
            ItemsListView1.Refreshing += reload;
            AboutPage.ThemeChanged += UIUpdate;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;
            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
            
            ItemsListView1.SelectedItem = null;
        }
        /// <summary>
        /// search bar clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Search_Clicked(object sender, EventArgs e)
        {
            SearchBar.IsVisible = !SearchBar.IsVisible;
            Header.Icon = SearchBar.IsVisible ? "@drawable/cancel.png" : "@drawable/search.png";
            if (SearchBar.IsVisible)
                SearchBar.Focus();
            else
                SearchBar.Text = "";
        }
        bool lang = AppData.isrus;
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0 || lang!= AppData.isrus)
                viewModel.LoadItemsCommand.Execute(null);
            lang = AppData.isrus;
        }
        /// <summary>
        /// interface update
        /// </summary>
        void UIUpdate()
        {
            viewModel.LoadItemsCommand.Execute(null);
            if (SearchBar.IsVisible)
            {
                string a = SearchBar.Text;
                SearchBar.Text = "";
                SearchBar.Text = a;
            }

        }
    }
}
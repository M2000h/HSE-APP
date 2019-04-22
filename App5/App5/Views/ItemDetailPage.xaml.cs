using System;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using App5.Models;
using App5.ViewModels;

namespace App5.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {


        ItemDetailViewModel viewModel;
        public ItemDetailPage(ItemDetailViewModel viewModel)
        {

            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
            UIUpdate();
            AboutPage.ThemeChanged += UIUpdate;
        }
        public void OpenLink()
        {
            string s = viewModel.Item.Link;
            s = s[0] == '/' ? "https://hse.ru" + s : s;
            Device.OpenUri(new Uri(s));
        }

        
        async void FavClicked(object sender, EventArgs args)
        {
            if (AppData.Links.Contains(viewModel.Item.Link))
                AppData.Links.Remove(viewModel.Item.Link);
            else
                AppData.Links.Add(viewModel.Item.Link);
            Header.Icon = viewModel.Item.FavSource;
            ItemsViewModel.LoadItemsCommand1.Execute(null);
            AppData.SettingChanged();
        }



        async void OnButtonClicked(object sender, EventArgs args)
        {
            var th = new Thread(OpenLink);
            th.Start();
        }
        void UIUpdate()
        {
            UIHeader.TextColor = AppData.FrontColor;
            UIExtraString.TextColor = AppData.FrontColor;
            UIDate.TextColor = AppData.FrontColor;
            UIPlace.TextColor = AppData.FrontColor;
        }
    }
}
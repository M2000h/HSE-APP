using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App5.Models;
using App5.ViewModels;
using App5.Views;
namespace App5.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public delegate void VoidDelegate();
        public static event VoidDelegate ThemeChanged;
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
        }
        async void English_Clicked(object sender, EventArgs args)
        {
            English.IsEnabled = false;
            Russian.IsEnabled = true;
            AppData.API_Link = "https://shakura.dev/hseapien";
            ItemsViewModel.LoadItemsCommand1.Execute(null);

        }
        async void Black_Clicked(object sender, EventArgs args)
        {
            AppData.IsThemeWhite = false;
            UIUpdate();

        }
        async void White_Clicked(object sender, EventArgs args)
        {
            AppData.IsThemeWhite = true;
            UIUpdate();
        }
        void UIUpdate()
        {
            StackLayout1.BackgroundColor = AppData.BackgroundColor;
            LANG_TEXT.TextColor = AppData.FrontColor;
            THEME_TEXT.TextColor = AppData.FrontColor;
            ThemeChanged();


        }
    }
}
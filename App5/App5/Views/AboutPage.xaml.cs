﻿using System;

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
        public static event Action ThemeChanged;
        public static void f() => ThemeChanged();
        public AboutPage()
        {
            InitializeComponent();
            ThemeChanged += UIUpdate;
            English.IsEnabled = AppData.isrus;
            Russian.IsEnabled = !AppData.isrus;
        }
        async void Russian_Clicked(object sender, EventArgs args)
        {
            Russian.IsEnabled = false;
            English.IsEnabled = true;
            AppData.isrus = true;
            AppData.SettingChanged();
            ItemsViewModel.LoadItemsCommand1.Execute(null);
        }
        async void English_Clicked(object sender, EventArgs args)
        {
            English.IsEnabled = false;
            Russian.IsEnabled = true;
            AppData.isrus = false;
            AppData.SettingChanged();
            ItemsViewModel.LoadItemsCommand1.Execute(null);

        }
        async void Black_Clicked(object sender, EventArgs args)
        {
            AppData.IsThemeWhite = false;
            AppData.SettingChanged();
            ThemeChanged();

        }
        async void White_Clicked(object sender, EventArgs args)
        {
            AppData.IsThemeWhite = true;
            AppData.SettingChanged();
            ThemeChanged();
        }
        void UIUpdate()
        {
            StackLayout1.BackgroundColor = AppData.BackgroundColor;
            LANG_TEXT.TextColor = AppData.FrontColor;
            THEME_TEXT.TextColor = AppData.FrontColor;
        }
    }
}
using System;
using App5.Models;
using App5.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App5.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage() 
        {
            InitializeComponent();
            AboutPage.ThemeChanged += UIUpdate;
        }
        void UIUpdate()
        {
            ToolBar.BarBackgroundColor = AppData.BarBackgroundColor;
            ToolBar.BarTextColor = AppData.FrontColor;
            BackgroundColor = AppData.BackgroundColor;
            Xamarin.Forms.PlatformConfiguration.AndroidSpecific.TabbedPage.SetBarItemColor(ToolBar, AppData.FrontColor);
            Xamarin.Forms.PlatformConfiguration.AndroidSpecific.TabbedPage.SetBarSelectedItemColor(ToolBar, Color.FromRgb(93, 188, 210));
        }
    }
}
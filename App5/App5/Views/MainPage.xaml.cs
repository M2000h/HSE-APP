using System;
using App5.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App5.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        
        public delegate void Handler();
        static public event Handler UIChenged;
        static public void UI()
        {
            UIChenged();
        }
        public MainPage()
        {
            
            InitializeComponent();
            UIChenged += UIUpdate;
        }
        void UIUpdate()
        {
            ToolBar.BarBackgroundColor = AppData.BarBackgroundColor;
            ToolBar.BarTextColor = AppData.FrontColor;
            BackgroundColor = AppData.BackgroundColor;
        }
    }
}
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Text;

namespace App5.Models
{
    static class AppData
    {
        static public List<string> Links = new List<string>();
        static public string API_Link { set; get; } = "https://shakura.dev/hseapi";
        static public string ru;
        static public string en;
        static public string curr { get => API_Link == "https://shakura.dev/hseapi" ? ru : en; }
        static public bool IsThemeWhite = true;
        static public Color BackgroundColor { get => IsThemeWhite ? Color.White : Color.FromRgb(16, 16, 16); }
        static public Color BarBackgroundColor { get => IsThemeWhite ? Color.White : Color.FromRgb(10, 10, 10); }
        static public Color FrontColor { get => IsThemeWhite ? Color.Black : Color.White; }
        static public string Calendar { get => IsThemeWhite ? "@drawable/calendar.png" : "@drawable/calendarwhite.png"; }
    }
}

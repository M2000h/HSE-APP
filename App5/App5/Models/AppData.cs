using System;
using System.Collections.Generic;
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
    }
}

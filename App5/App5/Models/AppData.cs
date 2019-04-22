using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;
namespace App5.Models
{
    struct memory
    {
        static public bool isrus { set; get; }
        static public bool IsThemeWhite { set; get; }
    }
    static class AppData
    {
        static public List<string> Links = new List<string>();
        
        
        
        /// <summary>
        /// Langs
        /// </summary>
        static public string ru;
        static public string en;
        static public bool isrus { set; get; } = true;


        /// <summary>
        /// Colors
        /// </summary>
        static public bool IsThemeWhite { set; get; }  = true;
        static public Color BackgroundColor { get => IsThemeWhite ? Color.White : Color.FromRgb(16, 16, 16); }
        static public Color BarBackgroundColor { get => IsThemeWhite ? Color.White : Color.FromRgb(10, 10, 10); }
        static public Color FrontColor { get => IsThemeWhite ? Color.Black : Color.White; }



        //static AppData()
        //{
        //    XmlSerializer deser = new XmlSerializer(typeof(memory));
        //    using (FileStream fs = new FileStream(@"AppData.txt",
        //    FileMode.Open))
        //    {
        //        memory a = (memory)deser.Deserialize(fs);
        //    }
        //}
    }
}

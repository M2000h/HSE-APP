using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.IO;
using Newtonsoft.Json;

namespace App5.Models
{
    /// <summary>
    /// Sctruct of Data which writes to files
    /// </summary>
    struct FileStruct
    {
        public bool isrus { set; get; }
        public bool IsThemeWhite { set; get; }
        public List<string> Links;
    }
    static class AppData
    {
        static public Action SettingChanged;
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
        static public bool IsThemeWhite { set; get; } = true;
        static public Color BackgroundColor { get => IsThemeWhite ? Color.White : Color.FromRgb(16, 16, 16); }
        static public Color BarBackgroundColor { get => IsThemeWhite ? Color.White : Color.FromRgb(10, 10, 10); }
        static public Color FrontColor { get => IsThemeWhite ? Color.Black : Color.White; }
        
        static AppData()
        {
            SettingChanged += Load;
            /// <summary>
            /// Read from file
            /// </summary>
            try
            {
                FileStruct a;
                string json;
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                string filePath = Path.Combine(path, "AppData.txt");
                using (var file = File.Open(filePath, FileMode.Open, FileAccess.Read))
                using (var strm = new StreamReader(file))
                {
                    json = strm.ReadToEnd();
                }
                a = JsonConvert.DeserializeObject<FileStruct>(json);
                isrus = a.isrus;
                IsThemeWhite = a.IsThemeWhite;
                Links = a.Links;
            }
            catch (Exception e){}

        }
        /// <summary>
        /// Write to file
        /// </summary>
        static void Load()
        {
            try
            {
                FileStruct a = new FileStruct() {isrus=isrus,
                    IsThemeWhite= IsThemeWhite,
                    Links = Links};
                string json = JsonConvert.SerializeObject(a);

                string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                string filePath = Path.Combine(path, "AppData.txt");
                using (var file = File.Open(filePath, FileMode.Create, FileAccess.Write))
                using (var strm = new StreamWriter(file))
                {
                    strm.Write(json);
                }
            }
            catch (Exception e){}
        }
    }
}

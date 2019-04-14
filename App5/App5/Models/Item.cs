using System;

namespace App5.Models
{
    public class Item
    {
        public string Type { get; set; }
        public string Day { get; set; } = "";
        public string Header { get; set; } = "";
        public string Description { get => string.Join(", ", Tags); }
        public string ExtraString { get => string.Join(", ", Extra); }
        public string Link { get; set; } = "";
        public string Place { get; set; } = "";
        public string Time { get; set; } = "";
        public string Date { get => Time == "" ? Day : Day + ", " + Time; }
        //public string MainTag { get => Tags.Length > 0 ? Tags[0] : ""; }
        public string[] Tags { set; get; } = { };
        public string[] Extra { set; get; } = { };
        public bool DayVisible { get => Type == "Day"; }
        public bool ExtraVisible { get => ExtraString != "" && Type == "Event"; }
        public bool TimeVisible { get => Time != "" && Type == "Event"; }
        public bool PlaceVisible { get => Place != "" && Type == "Event"; }
        public bool TagsVisible { get => Tags.Length > 0 && Type == "Event"; }
        public bool HeaderVisible { get => Type == "Event"; }
        public bool Clickable { get => Type == "Event"; }
        public string FavSource { get => AppData.Links.Contains(Link) ? "Added.png" : "fplus.png"; }
    }
}
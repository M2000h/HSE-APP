using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using App5.Models;
using Newtonsoft.Json;
using App5.Views;

namespace App5.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;
        static public string Get(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                    return reader.ReadToEnd();
            }
            catch
            {
                return null;
            }

        }
        static public void RealoadData()
        {
            AppData.ru = Get("https://shakura.dev/hseapi");
            AppData.en = Get("https://shakura.dev/hseapien");
            AboutPage.f();
        }
        public MockDataStore()
        {
            
            Item[] data = JsonConvert.DeserializeObject<Item[]>(AppData.isrus ? AppData.ru : AppData.en);
            items = data.OfType<Item>().ToList();
        }
        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
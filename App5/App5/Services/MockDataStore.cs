using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using App5.Models;
using Newtonsoft.Json;
using App5.Views;

namespace App5.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        /// <summary>
        /// List of Items
        /// </summary>
        List<Item> items;
        /// <summary>
        /// Request to server
        /// </summary>
        /// <param name="url">Link</param>
        /// <returns></returns>
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
        /// <summary>
        /// Reloadl Data from server
        /// </summary>
        static public void RealoadData()
        {
            AppData.ru = Get("https://shakura.dev/hseapi");
            AppData.en = Get("https://shakura.dev/hseapien");
            AboutPage.f();
        }
        /// <summary>
        /// Local relaod data after swiching language
        /// </summary>
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
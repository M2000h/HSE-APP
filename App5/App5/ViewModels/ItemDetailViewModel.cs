using System;

using App5.Models;

namespace App5.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Header;
            Item = item;
        }   
    }
}

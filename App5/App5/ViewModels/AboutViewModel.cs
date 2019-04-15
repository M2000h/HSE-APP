using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace App5.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
        }

        public ICommand OpenWebCommand { get; }
    }
}
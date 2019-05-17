using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App5.Views;
using App5.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App5
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            MockDataStore.RealoadData();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

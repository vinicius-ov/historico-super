using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Todoer
{
    public partial class App : Application
    {

        public static ProductItemManager ProductItemManager { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            ProductItemManager = new ProductItemManager(new RestService());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

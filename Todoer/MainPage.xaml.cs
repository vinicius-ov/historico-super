using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todoer.Model;
using Xamarin.Forms;

namespace Todoer
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer

    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //dateEntry.SetBinding = 
        }

        async void OnSaveProduct(object sender, EventArgs args)
        {
            Console.WriteLine("vai salvar");
            var datePrice = (DatedPrice)BindingContext;
            var product = (Product)BindingContext;
            Console.WriteLine(datePrice);
            //Console.WriteLine(product);
            //App.ProductItemManager.SaveTaskAsync();
        }

    }
}

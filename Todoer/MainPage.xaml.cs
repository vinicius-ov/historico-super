using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Todoer.Model;
using Xamarin.Forms;

namespace Todoer
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer

    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Product> products = new ObservableCollection<Product>();
        //Product = new Product();

        public MainPage()
        {
            InitializeComponent();

            ProductListView.ItemsSource = products;
        }

        async void OnSaveProduct(object sender, EventArgs args)
        {
            var prodName = ProductNameEntry.Text;
            //Console.WriteLine("vai salvar");
            var date = DateEntry.Date;
            double price = double.Parse(PriceEntry.Text);
            var product = new Product();
            product.DisplayName = prodName;
            product.Prices.Add(new DatedPrice(date, price));

            //Console.WriteLine(datePrice);
            Console.WriteLine(product);

            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder instead

            var path = Path.Combine(libraryPath, "projects.sqlite");
            var db = new SQLiteConnection(path);
            db.CreateTable<Project>();
            db.Insert(new Project());
            //var project = db.Get<Project>(5); // primary key id of 5

            var projects = db.Table<Project>();
            var project = db.Get<Project>(1);

            int p = db.Table<Project>().Count();
            p = p + 1;
            //App.ProductItemManager.SaveTaskAsync();
        }
        async void ShowAddProductForm(object sender, EventArgs args)
        {
            FormStack.IsVisible = !FormStack.IsVisible; //true
        }

    }
}

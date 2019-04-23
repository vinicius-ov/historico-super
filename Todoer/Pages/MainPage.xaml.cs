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
        DatabaseManager DbManager = new DatabaseManager();
        ObservableCollection<Project> Projects;

        public MainPage()
        {
            InitializeComponent();
            Projects = new ObservableCollection<Project>(DbManager.FindAllProjects());
            ProjectsListView.ItemsSource = Projects;
        }

        async void OnSaveProduct(object sender, EventArgs args)
        {
            Console.WriteLine("vai salvar");
        }
        async void OnProjectSelected(ListView sender, SelectedItemChangedEventArgs args)
        {
            Console.WriteLine(args.SelectedItem.ToString());

            await Navigation.PushAsync(new ProjectDetailsPage((Project)args.SelectedItem));

        }
        async void ShowAddProductForm(object sender, EventArgs args)
        {
            FormStack.IsVisible = !FormStack.IsVisible; //true
        }

    }
}

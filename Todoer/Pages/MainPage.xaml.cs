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

            var lista = DbManager.FindVacantEmployees();
            int p = lista.Count;
        }

    async void OnProjectSelected(ListView sender, SelectedItemChangedEventArgs args)
        {
            Console.WriteLine(args.SelectedItem.ToString());
            var projectSelected = (Project)args.SelectedItem;
            await Navigation.PushAsync(new ProjectDetailsPage(projectSelected));
        }
    }
}

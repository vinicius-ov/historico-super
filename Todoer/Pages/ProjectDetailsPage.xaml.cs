using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Todoer.Model;
using Xamarin.Forms;

namespace Todoer
{
    public partial class ProjectDetailsPage : ContentPage
    {
        private Project Project { get; set; }
        private DatabaseManager DbManager = new DatabaseManager();
        ObservableCollection<Employee> Employees;
        ObservableCollection<Employee> Workers;

        public ProjectDetailsPage(Project project)
        {
            InitializeComponent();
            Project = project;

            Project.Workers = DbManager.GetProjectWorkers(Project.Id).Workers;

            BindingContext = Project;
            Workers = new ObservableCollection<Employee>(Project.Workers);
            WorkersListView.ItemsSource = Workers;
            Employees = new ObservableCollection<Employee>(DbManager.FindAllEmployees());
            EmployeesListView.ItemsSource = Employees;

        }
        public void OnAddEmployeeToProject(ListView sender, ItemTappedEventArgs args)
        {
            var employeeSelected = (Employee) args.Item;
            Workers.Add(employeeSelected);
            Employees.Remove(employeeSelected);
        }
        public void OnSaveProject(object sender, EventArgs args)
        {
            Project savingProject = Project;
            savingProject.Workers = new List<Employee>(Workers);
            Project = savingProject;
            DbManager.SaveProject(savingProject);
        }
    }
}

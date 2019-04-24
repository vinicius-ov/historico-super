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
            Employees = new ObservableCollection<Employee>(DbManager.FindVacantEmployees());
            EmployeesListView.ItemsSource = Employees;
            
        }
        public void OnAddEmployeeToProject(ListView sender, ItemTappedEventArgs args)
        {
            var employeeSelected = (Employee) args.Item;
            Workers.Add(employeeSelected);
            Project.addWorker(employeeSelected);
            Employees.Remove(employeeSelected);
        }

        protected override void OnDisappearing()
        {
            Project savingProject = Project;
            DbManager.SaveProject(savingProject);
        }
    }
}

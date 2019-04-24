using System;
using System.Collections.Generic;
using System.ComponentModel;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Todoer.Model
{
    [Table("projects")]
    public class Project : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }
        private string photoUrl = string.Empty;
        public string PhotoUrl
        {
            get
            {
                if (photoUrl.Length <= 0)
                {
                    return "https://www.hagana.com.br/wp-content/uploads/2015/09/default-no-image.png";
                }
                return photoUrl;
            }
            set => photoUrl = value;
        }
        public string Name { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string varName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(varName));
        }
        private List<Employee> workers = new List<Employee>();
        [ManyToMany(typeof(ProjectEmployee))]
        public List<Employee> Workers
        {
            get => workers;
            set
            {
                if (workers == value)
                {
                    return;
                }
                workers = value;
                OnPropertyChanged(nameof(Workers));
            }
        }



         public Project()
        {

        }

        public Project(string name, string photoUrl)
        {
            Name = name;
            PhotoUrl = photoUrl;
            Workers = new List<Employee>();
        }

        internal void RemoveWorker(Employee employeeSelected)
        {
            this.Workers.Remove(employeeSelected);
            OnPropertyChanged(nameof(Workers));
        }

        public void AddWorker(Employee employee)
        {
            this.Workers.Add(employee);
            OnPropertyChanged(nameof(Workers));
        }

        public override string ToString()
        {
            return "Project: " + Name + " " + PhotoUrl;
        }
    }
}

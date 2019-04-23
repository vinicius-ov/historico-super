using System;
using System.Collections.Generic;
using SQLite;

namespace Todoer.Model
{
    [Table("projects")]
    public class Project
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }
        public string PhotoUrl { get; set; }
        public string Name { get; set; }
        [ManyToMany(typeof(ProjectEmployee))]
        public List<Employee> Workers;

        public Project()
        {

        }

        public Project(string name, string photoUrl)
        {
            Name = name;
            PhotoUrl = photoUrl;
            Workers = new List<Employee>();
        }

        public override string ToString()
        {
            return "Project: " + Name + " " + PhotoUrl;
        }

        //public void AddEmployee(Employee employee)
        //{
        //    if (Workers == null){
        //        Workers = new List<Employee>();
        //    }
        //    Workers.Add(employee);
        //}
    }
}

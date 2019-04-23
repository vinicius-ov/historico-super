using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Todoer.Model
{
    [Table("projects")]
    public class Project
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

        [ManyToMany(typeof(ProjectEmployee))]
        public List<Employee> Workers { get; set; }

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

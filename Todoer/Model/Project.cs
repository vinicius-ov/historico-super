using System;
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

        public Project()
        {

        }

        public Project(string name, string photoUrl)
        {
            Name = name;
            PhotoUrl = photoUrl;
        }

        public override string ToString()
        {
            return "Project: " + Name + " " + PhotoUrl;
        }
    }
}

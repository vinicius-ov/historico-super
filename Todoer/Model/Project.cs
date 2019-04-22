using System;
using SQLite;

namespace Todoer.Model
{
    [Table("projects")]
    public class Project
    {
        public Project()
        {

        }

        public Project(string name, string photoUrl)
        {
            Name = name;
            PhotoUrl = photoUrl;
        }

        public string PhotoUrl { get; set; }
        public string Name { get; set; }
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }
    }
}

using System;
using SQLite;

namespace Todoer.Model
{
    [Table("employees")]
    public class Employee
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Skill { get; set; }

        public Employee(string name, string skill)
        {
            Name = name;
            Skill = skill;
        }

        public Employee()
        {

        }
        public override string ToString()
        {
            return "Project: " + Name + " " + Skill;
        }
    }
}

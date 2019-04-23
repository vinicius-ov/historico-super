using System;
using SQLite;

namespace Todoer.Model
{
    [Table("projects_employees")]
    public class ProjectEmployee
    {
        [Column("id_project")]
        public int id_project { get; set; }
        [Column("id_employee")]
        public int id_employee { get; set; }

        public ProjectEmployee()
        {
        }


    }
}

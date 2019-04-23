using System;
using SQLite;

namespace Todoer.Model
{
    [Table("projects_employees")]
    public class ProjectEmployee
    {
        [Column("id_project")]
        public int IdProject { get; set; }
        [Column("id_employee")]
        public int IdEmployee { get; set; }

        public ProjectEmployee()
        {
        }


    }
}

using System;
using System.Collections.Generic;
using System.IO;
using SQLite;
using Todoer.Model;
using System.Linq;
using SQLiteNetExtensions.Extensions;

namespace Todoer
{
    public class DatabaseManager
    {
        private SQLiteConnection Database { get; set; }

        public DatabaseManager()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder instead

            var path = Path.Combine(libraryPath, "projects.sqlite");
            Database = new SQLiteConnection(path);
            Database.CreateTable<Project>();
            Database.CreateTable<Employee>();
            Database.CreateTable<ProjectEmployee>();
            if (Database.Table<Project>().Count() <= 0)
            {
                Database.Insert(new Project("Wake Waves", "https://upload.wikimedia.org/wikipedia/commons/b/b1/Wave_cloud.jpg"));
                Database.Insert(new Project("Tre Duo", ""));
                Database.Insert(new Project("Antes do Depois", "https://3c1703fe8d.site.internapcdn.net/newman/gfx/news/hires/2018/31-stephenhawki.jpg"));
                Database.Insert(new Project("Capacitor de fluxo", "https://4.bp.blogspot.com/-75OvXjimFgo/VugGzmZrVII/AAAAAAAAC3U/PbWK7BARDuMA1-eMSCv25YXX-HXqKOZPg/s1600/capacitor_fluxo.jpg"));
                Database.Insert(new Project("Simulador G-Virus", "https://3.bp.blogspot.com/-SdPYoEq6jno/UAQrK060JXI/AAAAAAAAAQ0/-hJy-Y8SfJc/s1600/samp1.PNG"));
                Database.Insert(new Project("Ford Probe", "https://1.bp.blogspot.com/-DdZWBkmK_9U/TmZnyCXpqYI/AAAAAAAABsw/oTQb_eNWHeg/s1600/ford_probe_custom_001_bttfpt.JPG"));

            }
            if (Database.Table<Employee>().Count() <= 0)
            {
                Database.Insert(new Employee("Rosângela Bruna Costa", "Frontend"));
                Database.Insert(new Employee("José Firmino", "Analista"));
                Database.Insert(new Employee("Furzo Kimano", "Tester"));
                Database.Insert(new Employee("Manilo Orve", "Backend"));
                Database.Insert(new Employee("Pedro Garcia", "Frontend"));
                Database.Insert(new Employee("Bernardo Kevin Carlos Eduardo Figueiredo", "Analista"));
                Database.Insert(new Employee("Murilo Renato Iago Sales", "Tester"));
                Database.Insert(new Employee("Nathan Kevin da Costa", "Backend"));
                Database.Insert(new Employee("Luan Thomas Rocha", "Frontend"));
                Database.Insert(new Employee("Tiago Enrico Vitor Costa", "Analista"));
                Database.Insert(new Employee("Jéssica Marli Luana Lopes", "Tester"));
                Database.Insert(new Employee("Nicole Helena Luciana Castro", "Backend"));
                Database.Insert(new Employee("Lorena Pietra Tereza Nunes", "Tester"));
                Database.Insert(new Employee("Bárbara Letícia Gonçalves", "Backend"));
                Database.Insert(new Employee("Kamilly Lara Ayla Ribeiro", "Frontend"));
                Database.Insert(new Employee("Mariana Nicole Isabelly Ferreira", "Analista"));
                Database.Insert(new Employee("Laís Esther Laura Farias", "Tester"));
                Database.Insert(new Employee("Rebeca Emily Raimunda Oliveira", "Backend"));
                Database.Insert(new Employee("Diego Calebe Pereira", "Frontend"));
                Database.Insert(new Employee("Benício Fernando Monteiro", "Analista"));
                Database.Insert(new Employee("Felipe Giovanni Ribeiro", "Tester"));
                Database.Insert(new Employee("Marcos Rodrigo Jorge de Paula", "Backend"));
                Database.Insert(new Employee("Renan Joaquim da Rocha", "Frontend"));
                Database.Insert(new Employee("Sabrina Fátima Drumond", "Backend"));
            }
        }

        internal Project GetProjectWorkers(int id)
        {
            return Database.GetWithChildren<Project>(id);
        }

        internal List<Project> FindAllProjects()
        {
            return Database.GetAllWithChildren<Project>(); 
        }

        internal List<Employee> FindAllEmployees()
        {
            return Database.Table<Employee>().ToList();
        }

        internal int SaveProject(Project project)
        {
            Database.UpdateWithChildren(project);
            return 1;
        }
        //list projects
        //list employees in given project
        //get project by id
        //database add employee to project
        //remove emplo from project
        //get vacant employees
    }
}

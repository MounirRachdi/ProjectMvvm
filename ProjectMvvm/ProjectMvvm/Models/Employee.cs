using Root.Services.Sqlite;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMvvm.Models
{
    public class Employee : IBaseTable
    { [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        
   
        public bool IsVisible { get; set; }
    }
}

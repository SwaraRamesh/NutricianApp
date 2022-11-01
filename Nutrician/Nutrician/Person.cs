using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nutrician
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String username { get; set; }
        public String password { get; set; }
    }
}

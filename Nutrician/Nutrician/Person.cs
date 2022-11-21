using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nutrician
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }
        [Unique, NotNull]
        public String Username { get; set; }
        [NotNull]
        public String Password { get; set; }
    }
}
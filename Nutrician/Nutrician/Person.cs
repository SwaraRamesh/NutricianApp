using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nutrician
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        // ? means it can be null or it is nullable
        public int? Id { get; set; }
        [Unique, NotNull]
        public String Username { get; set; }
        [NotNull]
        public String Password { get; set; }
        [NotNull]
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
    }
}
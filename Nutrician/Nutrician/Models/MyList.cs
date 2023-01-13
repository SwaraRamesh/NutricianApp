using System;
using SQLite;

namespace Nutrician
{
	public class MyList
	{
        [PrimaryKey, AutoIncrement]
        // ? means it can be null or it is nullable
        public int? Id { get; set; }
        
        public String Username { get; set; }
        
        public String Name { get; set; }
        
        public int medId { get; set; }

    }
}
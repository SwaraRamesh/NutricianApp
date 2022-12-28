using System;
using SQLite;

namespace Nutrician
{
	public class MyList
	{
        [PrimaryKey, AutoIncrement]
        // ? means it can be null or it is nullable
        public int? Id { get; set; }
        [Unique, NotNull]
        public String Username { get; set; }

        public MyList()
		{
		}
	}
}
using System;
using SQLite;

namespace Nutrician.Models
{
	public class UserNote
	{


        [PrimaryKey, AutoIncrement]
        // ? means it can be null or it is nullable
        public int? Id { get; set; }
        [NotNull]
        public String Note { get; set; }
	}
}


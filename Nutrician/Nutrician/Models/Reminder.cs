using System;
using SQLite;

namespace Nutrician.Models
{
    public class Reminder
    {
        [PrimaryKey, AutoIncrement]
        // ? means it can be null or it is nullable
        public int? Id { get; set; }
        [Unique, NotNull]
        public Boolean Status { get; set; }
        public String Date { get; set; }
        public String Description { get; set; }

        public Reminder()
		{
		}
	}
}


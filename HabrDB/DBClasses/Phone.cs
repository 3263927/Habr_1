using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HabrDB.DBClasses
{
	[Table("Phones", Schema ="Habr")]
	public class Phone
	{
		[Key]
		public int Id { get; set; }
		public String Model { get; set; }
		public DateTime DayZero { get; set; }
	}
}

using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp2POC.Core.Models
{
	public class SQLExampleObject
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Name { get; set; }
		public int Count { get; set; }
		public string Description { get; set; }
	}
}

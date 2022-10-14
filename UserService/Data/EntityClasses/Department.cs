using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Diagnostics.CodeAnalysis;

namespace Data
{
	public class Department
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
		[JsonIgnore]
		//Primary key , Auto increment | bunu ister attributelarla istersek fluent api'yla yapabiliriz.
        public int DepartmentId { get; set; }
		public string DepartmentName { get; set; }
		public int Floor { get; set; }

		[JsonIgnore]
		//Referans Property
        public IList<User>? Users { get; set; }

	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data
{   //Solid prensipleri
    public class User
    {
        public string Isim { get; set; }
        public string Soyisim { get; set; }

        [JsonIgnore]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        // | Primary key, auto increment | bunu ister attributelarla istersek fluent api'yla yapabiliriz.
        public int UserId { get; set; }
        public int Yas { get; set; }
        public string Memleket { get; set; }

        [JsonIgnore]
        //Referans property
        public Department? Department { get; set; }
        //Foreign key
        public int DepartmentId { get; set; }


    }
}

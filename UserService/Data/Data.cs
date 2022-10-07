using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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


        public int Id { get; set; }


        public int Yas { get; set; }

        public string Memleket { get; set; }

    }
}

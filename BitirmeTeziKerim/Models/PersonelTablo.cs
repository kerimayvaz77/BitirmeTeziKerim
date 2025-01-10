using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeTeziKerim.Models
{
    public class PersonelTablo
    {
        [Key]
        public int Id { get; set; }
       
        public string AkademikPersonel { get; set; }
        public string Unvan { get; set; }
        public int Sayi { get; set; }
        public string IdariPersonel { get; set; }
        public string Sinif { get; set; }
        public int Sayi1 { get; set; }
    }
}

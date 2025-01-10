using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeTeziKerim.Models
{
    public class SayilarTablo
    {

        [Key]
        public int Id { get; set; }
        public string OgrenimDuzeyi { get; set; }
        public string AkademikBirim { get; set; }
        public int Kadin { get; set; }
        public int Erkek { get; set; }
        public int Toplam { get; set; }

        [ForeignKey("Sayilar")]
        public int SayilarId { get; set; }
        public Sayilar Sayilar { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeTeziKerim.Models
{
    public class AdminTablo
    {
        [Key]
        public int Id { get; set; }

        public string KullaniciIsmi { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
    }
}

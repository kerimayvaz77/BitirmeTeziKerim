using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeTeziKerim.Models
{
    public class Sayilar
    {
        [Key]
        public int Id { get; set; }
        public string SayiTablo { get; set; }
    }
}

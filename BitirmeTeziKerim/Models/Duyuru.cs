using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeTeziKerim.Models
{
    public class Duyuru
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        public string Aciklama { get; set; }
    }
}

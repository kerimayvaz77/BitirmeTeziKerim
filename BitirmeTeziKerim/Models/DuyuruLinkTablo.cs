using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeTeziKerim.Models
{
    public class DuyuruLinkTablo
    {
        [Key]
        public int Id { get; set; }

        public string KoyulacakLink { get; set; }
        public string KoyulacakLink2 { get; set; }
     
    }
}

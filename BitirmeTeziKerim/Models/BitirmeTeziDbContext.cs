using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeTeziKerim.Models
{
    public class BitirmeTeziDbContext : DbContext
    {
        public BitirmeTeziDbContext(DbContextOptions<BitirmeTeziDbContext> options) : base(options)
        {
        }

        public DbSet<Sayilar> Sayilars { get; set; }
        public DbSet<SayilarTablo> SayilarTablos { get; set; }
        public DbSet<PersonelTablo> PersonelTablos { get; set; }
        public DbSet<AdminTablo> AdminTablos { get; set; }
        public DbSet<DuyuruLinkTablo> DuyuruLinks { get; set; }
        public DbSet<Duyuru> Duyurues { get; set; }
    }
}
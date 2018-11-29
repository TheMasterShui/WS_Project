using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Prodavnca_Projekat.Models
{
    public class ProdavnicaContext : DbContext
    {
        public ProdavnicaContext() : base("Prodavnica") { }

        public DbSet<Proizvodi> Proizvodi { get; set; }
    }
}
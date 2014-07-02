using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebForms.SportsStore.Models.Repository
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(string conName)
            : base(conName)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
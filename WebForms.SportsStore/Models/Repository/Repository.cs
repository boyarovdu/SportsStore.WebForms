using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForms.SportsStore.Models.Repository
{
    public class Repository
    {
        private EFDbContext context = new EFDbContext("EFDbContext");
        
        public IQueryable<Product> Products
        {
            get { return context.Products; }
        }
    }
}
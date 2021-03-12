using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace crm.Models
{
    public class CrmContext : DbContext
    {  
        public CrmContext() : base("name=CrmContext")
        {
        }

        public DbSet<BlogCategoria> BlogCategorias { get; set; }
        public DbSet<BlogArtigo> BlogArtigos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
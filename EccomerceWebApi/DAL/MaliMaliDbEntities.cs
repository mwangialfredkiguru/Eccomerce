using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EccomerceWebApi.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EccomerceWebApi.DAL
{
    public class MaliMaliDbEntities : DbContext
    {
        public MaliMaliDbEntities() : base("MaliMaliDbEntities")
        {
        }

        public DbSet<Customer_Reg_Table> Customer_Reg_Table { get; set; }
        public DbSet<Fcm_Token_Table> Fcm_Token_Table { get; set; }
        public DbSet<Products_Table> Products_Table { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
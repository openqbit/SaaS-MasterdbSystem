using OpenQbit.Masterdb.Common.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenQbit.Masterdb.DataAccsess.DAL
{
   public class MasterDBContext : DbContext
    {
        public MasterDBContext() : base("MasterDataBase")
        {
            this.Configuration.ProxyCreationEnabled = false;

        }

        public DbSet<Resorce> Resorce { get; set; }
        public DbSet<Details> Details { get; set; }
        public DbSet<ResourceHierachy> ResourceHierachy { get; set; }
        public DbSet<ResourceHierachyType> ResourceHierachyType { get; set; }
        public DbSet<ResourceType> ResourceType { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}

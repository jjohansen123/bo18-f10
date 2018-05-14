using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using BachelorModel;
using System.Data.SqlClient;

namespace BachelorDataAccess
{
    public partial class BachelorContext : DbContext
    {
        public virtual DbSet<Node> Nodes { get; set; }
        public virtual DbSet<HighId> HighestNode { get; set; }
        public virtual DbSet<Site> Sites { get; set; }
        public virtual DbSet<Devices> Model { get; set; }
        public BachelorContext() : base(@"Data Source=donau.hiof.no;Initial Catalog=kristei;Integrated Security=False;User ID=kristei;Password=qDW7OP;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(new BachelorDBInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
            modelBuilder.Entity<Node>()

                .Map(m =>
                {
                    m.ToTable("Nodes");
                });

            modelBuilder.Entity<HighId>()
                .HasKey(a => a.SiteId)
                .Map(m =>
                {
                    m.ToTable("HighestLocalID");

                });
            modelBuilder.Entity<Devices>()
                .HasKey(a => a.ModelId)
                .Map(m =>
                {
                    m.ToTable("Devices");

                });

        }
    }

}

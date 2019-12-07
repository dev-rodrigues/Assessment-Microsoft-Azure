using Core.Models;
using Core.Models.States;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context {
    public class DatabaseContext : DbContext {

        private static string connection_string = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Data.Context.DatabaseContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public DatabaseContext() : base(connection_string) {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
            Database.SetInitializer<DatabaseContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Friend>().MapToStoredProcedures();
            modelBuilder.Entity<Country>().MapToStoredProcedures();
            modelBuilder.Entity<State>().MapToStoredProcedures();
            modelBuilder.Entity<Country>().HasMany(x => x.States);
        }

        public DbSet<Friend> Friends {
            get; set;
        }

        public DbSet<Country> Countries {
            get; set;
        }

        public DbSet<State> States {
            get; set;
        }

        
        //protected void OnConfiguring { get => onConfiguring; set => this.onConfiguring = value; }
    }
}
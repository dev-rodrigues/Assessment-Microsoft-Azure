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

        private static string connection_string = "DefaultConnection";

        public DatabaseContext() : base(connection_string) {
            //Configuration.LazyLoadingEnabled = false;
            //Configuration.ProxyCreationEnabled = false;
            //Database.SetInitializer<DatabaseContext>(null);
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder) {
        //    //modelBuilder.Entity<Friend>().MapToStoredProcedures();
        //    //modelBuilder.Entity<Country>().MapToStoredProcedures();
        //    //modelBuilder.Entity<State>().MapToStoredProcedures();
        //    //modelBuilder.Entity<Country>().HasMany(x => x.States);
        //}

        public DbSet<Friend> Friends {
            get; set;
        }

        public DbSet<Country> Countries {
            get; set;
        }

        public DbSet<State> States {
            get; set;
        }
    }
}
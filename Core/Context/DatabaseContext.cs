using Core.Models;
using Core.Models.States;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context {
    public class DatabaseContext : DbContext {

        public DbSet<Friend> Friends {
            get; set;
        }

        public DbSet<Country> Countries {
            get; set;
        }

        public DbSet<State> States {
            get; set;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Friend>().MapToStoredProcedures();
            modelBuilder.Entity<Country>().MapToStoredProcedures();
            modelBuilder.Entity<State>().MapToStoredProcedures();
        }
    }
}
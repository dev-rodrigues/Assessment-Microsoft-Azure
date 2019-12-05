﻿using Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context {
    public class DatabaseContext : DbContext {

        private static string ConnectionString = "DefaultConnection";

        public DbSet<Friend> Friends {
            get; set;
        }

        public DbSet<Friend> Countries {
            get; set;
        }

        public DatabaseContext() : base(ConnectionString) {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        public static DatabaseContext Create() {
            return new DatabaseContext();
        }
    }
}
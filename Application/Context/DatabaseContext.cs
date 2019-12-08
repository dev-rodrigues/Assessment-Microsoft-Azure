using System.Data.Entity;
using Application.Models.Friends;
using Application.Models.Territory.Countries;
using Application.Models.Territory.States;

namespace Application.Database {
    public class DatabaseContext : DbContext {

        public DbSet<State> States {
            get; set;
        }

        public DbSet<Country> Countries {
            get; set;
        }

        public DbSet<Friend> Friends {
            get; set;
        }

        public DatabaseContext() : base("Assessment") {
            //Configuration.LazyLoadingEnabled = false;
            //Configuration.ProxyCreationEnabled = false;
        }

    }
}

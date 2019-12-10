using System.Data.Entity;
using Application.Models.Friends;
using Application.Models.Friendships;
using Application.Models.Territory.Countries;
using Application.Models.Territory.States;

namespace Application.Database {
    public class DatabaseContext : DbContext {

        private static string connection_string = @"C:\Users\c.rodrigues.junior\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB";

        public DbSet<State> States {
            get; set;
        }

        public DbSet<Country> Countries {
            get; set;
        }

        public DbSet<Friend> Friends {
            get; set;
        }

        public DbSet<Friendship> Friendships {
            get; set;
        }

        public DatabaseContext() : base(connection_string) {
            //Configuration.LazyLoadingEnabled = false;
            //Configuration.ProxyCreationEnabled = false;
        }

    }
}

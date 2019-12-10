using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Territory.Countries;
using db = Application.Database.Database;

namespace Application.Repository.Territory.Countries {
    public class CountryRepository : ICountry {
        private static string connection_string = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Assessment;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public async Task<bool> Delete(Country country) {
            try {
                db.GetInstance.Countries.Remove(country);
                await db.GetInstance.SaveChangesAsync();
                return true;
            } catch(Exception e) {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool DeleteSP(int id_country) {
            using(SqlConnection conn = new SqlConnection(connection_string)) {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Delete_Country";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id_country", id_country);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return true;
            }
        }

        public async Task<Country> Find(int id_country) {
            try {
                return await db.GetInstance.Countries.FindAsync(id_country);
            } catch(Exception e) {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Country> Index() {
            return db.GetInstance.Countries.ToList();
        }

        public async Task<Country> Save(Country country) {
            try {
                db.GetInstance.Countries.Add(country);
                await db.GetInstance.SaveChangesAsync();
                return country;
            } catch(Exception e) {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<Country> Update(Country country) {
            try {
                db.GetInstance.Entry<Country>(country).State = EntityState.Modified;
                await db.GetInstance.SaveChangesAsync();
                return country;
            } catch(Exception e) {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}

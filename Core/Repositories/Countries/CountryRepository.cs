using Core.Models;
using Data.Context;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.Countries {
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository {

        private static string connection_string = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Data.Context.DatabaseContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public IQueryable<Country> Index() {
            var lista = from p in base.FindAll() select p;
            return lista;
        }
        public Country Show(string country) {
            using(SqlConnection conn = new SqlConnection(connection_string)) {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Country_Select";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("city", country);
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while(dr.Read()) {
                    var obj = new Country() {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = dr["Name"].ToString(),
                        URLImage = dr["URLImage"].ToString(),
                        States = null
                    };
                    return obj;
                }
            }
            return null;
        }

        public Country Show(int id) {
            return base.Find(id);
        }


        public Country Store(Country model) {
            return base.Save(model);
        }

        public Country Update(Country model) {
            return base.Edit(model);
        }
    }
}

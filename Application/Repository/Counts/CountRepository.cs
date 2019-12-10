using Application.Models.Counts;
using Application.Models.Friends;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using db = Application.Database.Database;

namespace Application.Repository.Counts {
    public class CountRepository : ICount {

        private static string connection_string = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Assessment;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public async Task<Count> Sum() {
            var count = new Count();

            try {
                var friends = await db.GetInstance.Friends.ToListAsync();
                var countries = await db.GetInstance.Countries.ToListAsync();
                var states = await db.GetInstance.States.ToListAsync();

                count.SumCountry = countries.Count;
                count.SumFriend = friends.Count;
                count.SumState = states.Count;
                return count;
            } catch(Exception e) {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<Count> SumSP() {
            var count = new Count();

            using(SqlConnection conn = new SqlConnection(connection_string)) {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Busca_Somatorio";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while(dr.Read()) {
                    count.SumCountry = Convert.ToInt32(dr["SUM_PAIS"]);
                    count.SumState = Convert.ToInt32(dr["SUM_ESTADO"]);
                    count.SumFriend = Convert.ToInt32(dr["SUM_AMIGOS"]);
                }
            }
            return count;
        }
    }
}

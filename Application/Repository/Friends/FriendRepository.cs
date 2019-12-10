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

namespace Application.Repository.Territory.Friends {
    public class FriendRepository : IFriend {

        private static string connection_string = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Assessment;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public async Task<bool> Delete(Friend country) {
            try {
                db.GetInstance.Friends.Remove(country);
                await db.GetInstance.SaveChangesAsync();
                return true;
            } catch(Exception e) {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool DeleteSP(int id_friend) {
            var sem_amizades = ApagarAmizades(id_friend);
            var apagado = ApagarFriend(id_friend);

            if(sem_amizades && apagado) {
                return true;
            }
            return false;
        }

        private bool ApagarAmizades(int id_friend) {
            using(SqlConnection conn = new SqlConnection(connection_string)) {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Delete_Amizade";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id_user", id_friend);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return true;
            }
        }

        private bool ApagarFriend(int id_friend) {
            using(SqlConnection conn = new SqlConnection(connection_string)) {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Delete_friend";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id_friend", id_friend);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return true;
            }
        }

        public async Task<Friend> Find(int id_country) {
            try {
                return await db.GetInstance.Friends.FindAsync(id_country);
            } catch(Exception e) {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Friend> Index() {
            return db.GetInstance.Friends.ToList();
        }

        public async Task<Friend> Save(Friend friend) {
            try {
                db.GetInstance.Friends.Add(friend);
                await db.GetInstance.SaveChangesAsync();
                return friend;
            } catch(Exception e) {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<Friend> Update(Friend friend) {
            try {
                db.GetInstance.Entry<Friend>(friend).State = EntityState.Modified;
                await db.GetInstance.SaveChangesAsync();
                return friend;
            } catch(Exception e) {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}

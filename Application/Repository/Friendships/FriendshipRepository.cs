using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Friends;
using Application.Models.Friendships;
using db = Application.Database.Database;

namespace Application.Repository.Friendships {
    public class FriendshipRepository : IFriendship {
        public async Task<bool> Delete(Friendship friendship) {
            try {
                db.GetInstance.Friendships.Remove(friendship);
                await db.GetInstance.SaveChangesAsync();
                return true;
            } catch(Exception e) {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<Friendship> Find(int id_connection) {
            return await db.GetInstance.Friendships.FindAsync(id_connection);
        }

        public List<FriendshipDTO> Friends(int user_id) {
            var all_friendships = db.GetInstance.Friendships.ToList();
            var my_friendsships = new List<FriendshipDTO>();

            foreach(var f in all_friendships) {
                if(f.Follower.Id == user_id) {
                    var dto = new FriendshipDTO() {
                        IdConnection = f.Id,
                        IdSeguido = f.Followed.Id,
                        NomeSeguido = f.Followed.Name,
                        SobreNome = f.Followed.LastName
                    };
                    my_friendsships.Add(dto);
                }
            }
            return my_friendsships;
        }

        public async Task<Friendship> Save(Friendship friendship) {
            try {
                db.GetInstance.Friendships.Add(friendship);
                await db.GetInstance.SaveChangesAsync();
                return friendship;
            } catch(Exception e) {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<Friendship> Update(Friendship country) {
            try {
                db.GetInstance.Entry<Friendship>(country).State = EntityState.Modified;
                await db.GetInstance.SaveChangesAsync();
                return country;
            } catch(Exception e) {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}

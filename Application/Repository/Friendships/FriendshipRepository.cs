using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Friends;
using Application.Models.Friendships;
using db = Application.Database.Database;

namespace Application.Repository.Friendships {
    public class FriendshipRepository : IFriendship {
        public List<Friend> Friends(int user_id) {
            var all_friendships = db.GetInstance.Friendships.ToList();
            var my_friendsships = new List<Friend>();

            foreach(var f in all_friendships) {
                if(f.Follower.Id == user_id) {
                    my_friendsships.Add(f.Followed);
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
    }
}

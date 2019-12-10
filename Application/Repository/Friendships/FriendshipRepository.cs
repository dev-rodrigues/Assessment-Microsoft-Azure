using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Friendships;
using db = Application.Database.Database;

namespace Application.Repository.Friendships {
    public class FriendshipRepository : IFriendship {
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

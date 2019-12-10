using Application.Models.Friends;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using db = Application.Database.Database;

namespace Application.Repository.Counts {
    public class FriendCountRepository : IFriendCount {
        public async Task<FriendCount> Sum() {
            var count = new FriendCount();
            try {
                var total = await db.GetInstance.Friends.ToListAsync();
                count.Sum = total.Count;
                return count;
            } catch(Exception e) {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}

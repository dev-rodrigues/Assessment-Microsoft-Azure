using Application.Models.Counts;
using Application.Models.Friends;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using db = Application.Database.Database;

namespace Application.Repository.Counts {
    public class CountRepository : ICount {
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
    }
}

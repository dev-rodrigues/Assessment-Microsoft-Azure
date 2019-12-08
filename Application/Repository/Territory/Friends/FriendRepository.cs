using Application.Models.Friends;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using db = Application.Database.Database;

namespace Application.Repository.Territory.Friends {
    public class FriendRepository : IFriend {
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

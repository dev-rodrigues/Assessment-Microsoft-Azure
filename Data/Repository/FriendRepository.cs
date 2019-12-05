using Core.Models;
using Core.Service;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository {
    public class FriendRepository : IFriend {

        public async Task<Country> Save(Country obj) {
            try {
                Database.GetContext.Friends.Add(obj);
                await Database.GetContext.SaveChangesAsync();
            } catch(Exception e) {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public Task<Country> Update(Country old) {
            throw new NotImplementedException();
        }

        public Task Delete(int id) {
            throw new NotImplementedException();
        }

        public Task<Country> Find(int id) {
            throw new NotImplementedException();
        }
        public Task<List<Country>> FindAll(int id) {
            throw new NotImplementedException();
        }
    }
}
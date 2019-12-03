using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service {
    public interface IFriend {
        Task<Friend> Save(Friend obj);

        Task<Friend> Update(Friend old);

        Task Delete(int id);

        Task<Friend> Find(int id);
        
        Task<List<Friend>> FindAll(int id);
    }
}
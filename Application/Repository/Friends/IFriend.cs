using Application.Models.Friends;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Territory.Friends {
    public interface IFriend {
        Task<Friend> Save(Friend country);
        Task<Friend> Update(Friend country);
        Task<bool> Delete(Friend country);
        bool DeleteSP(int id_friend);
        Task<Friend> Find(int id_country);
        List<Friend> Index();
    }
}

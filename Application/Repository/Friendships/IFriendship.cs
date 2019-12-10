using Application.Models.Friends;
using Application.Models.Friendships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Friendships {
    public interface IFriendship {
        Task<Friendship> Save(Friendship country);
        List<Friend> Friends(int user_id);

    }
}

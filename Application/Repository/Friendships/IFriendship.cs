using Application.Models.Friends;
using Application.Models.Friendships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Friendships {
    public interface IFriendship {
        Task<Friendship> Save(Friendship friendship);
        List<FriendshipDTO> Friends(int user_id);
        Task<Friendship> Find(int id_connection);
        Task<Friendship> Update(Friendship friendship);

        Task<bool> Delete(Friendship friendship);
    }
}

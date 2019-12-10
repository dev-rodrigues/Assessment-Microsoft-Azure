using Application.Models.Friends;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Friendships {
    public class Friendship {

        public int Id { get; set; }

        public virtual Friend Follower { get; set; }
        public virtual Friend Followed { get; set; }
    }
}

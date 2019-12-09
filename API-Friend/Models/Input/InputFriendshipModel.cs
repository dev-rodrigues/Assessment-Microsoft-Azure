using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Friend.Models.Input {
    public class InputFriendshipModel {
        public int IdFollowed { get; set; }
        public int IdFollower { get; set; }
    }
}
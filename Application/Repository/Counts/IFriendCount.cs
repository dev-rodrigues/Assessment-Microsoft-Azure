using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Counts {
    public interface IFriendCount {
        Task<FriendCount> Sum();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Friendships {
    public class FriendshipDTO {
        public int IdConnection { get; set; }

        public int IdSeguido { get; set; }
        public string NomeSeguido { get; set; }
        public string SobreNome { get; set; }
    }
}

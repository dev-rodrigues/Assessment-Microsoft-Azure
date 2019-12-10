using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models {
    public class IndexConexaoViewModel {
        public ICollection<ConexaoViewModel> Conexoes { get; set; }
        public ICollection<FriendViewModel> Friends { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Friend.Models.Input {
    public class InputConectarModel {
        public string id_seguidor { get; set; }
        public string id_seguido { get; set; }
    }
}
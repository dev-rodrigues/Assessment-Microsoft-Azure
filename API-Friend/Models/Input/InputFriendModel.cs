using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Friend.Models.Input {
    public class InputFriendModel {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string BirthDate { get; set; }

        public int IdCountry { get; set; }
        public int IdState { get; set; }
    }
}
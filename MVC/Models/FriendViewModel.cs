using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class FriendViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string BirthDate { get; set; }
        public PaisViewModel Country { get; set; }
        public EstadoViewModel State { get; set; }
    }
}
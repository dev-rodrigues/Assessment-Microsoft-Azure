using Application.Models.Friendships;
using Application.Models.Territory.Countries;
using Application.Models.Territory.States;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Friends {
    public class Friend {
        public Friend() {
            //this.Friends = new HashSet<Friend>();
            //Friendships = new HashSet<Friendship>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public DateTime BirthDate { get; set; }
        public string URLImg { get; set; }

        //public virtual ICollection<Friend> Friends { get; set; }
        //public virtual ICollection<Friendship> Friendships { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        [ForeignKey("State")]
        public int StateId { get; set; }
        public virtual State State { get; set; }

    }
}

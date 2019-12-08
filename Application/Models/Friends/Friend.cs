using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Friends {
    public class Friend {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<Friend> Friends { get; set; }

        public Friend() {
            this.Friends = new HashSet<Friend>();
        }
    }
}

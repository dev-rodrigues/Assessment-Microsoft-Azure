using Core.Models.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models {
    public class Country {

        public Country() {
            this.States = new HashSet<State>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string URLImage { get; set; }

        public virtual ICollection<State> States { get; set; }
    }
}

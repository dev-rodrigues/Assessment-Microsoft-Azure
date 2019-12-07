using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.States {
    public class State {
        public State() {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string URLImage { get; set; }

        public virtual Country Country { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.States {
    public class State {
        public State() {

        }

        [Key()]
        public int Id { get; set; }
        public string Name { get; set; }
        public string URLImage { get; set; }

        [ForeignKey("Country")]
        public int CountryID { get; set; }
        public virtual Country Country { get; set; }
    }
}

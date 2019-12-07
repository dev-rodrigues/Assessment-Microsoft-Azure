using Core.Models.States;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models {
    public class Country {

        public Country() {
            //this.States = new List<State>();
        }
        
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string URLImage { get; set; }

        
        public virtual List<State> States { get; set; }
    }
}

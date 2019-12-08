using Application.Models.Territory.States;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Territory.Countries {
    public class Country {
        [Key()]
        public int Id { get; set; }

        public string Name { get; set; }

        public string UrlPicture { get; set; }

        public virtual ICollection<State> States { get; set; }
    }
}

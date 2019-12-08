using Application.Models.Territory.Countries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Territory.States {
    public class State {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlPicture { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}

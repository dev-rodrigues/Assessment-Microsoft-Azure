using Application.Models.Territory.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Country.Models.OutputModel {
    public class OutputStateModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdImage { get; set; }

        public OutputCountryModel Country { get; set; }

        public static OutputStateModel ConvertState(State state) {
            var converted_country = new OutputCountryModel() {
                Id = state.Country.Id,
                Name = state.Country.Name
            };

            OutputStateModel output = new OutputStateModel() {
                Id = state.Id,
                IdImage = state.UrlPicture,
                Name = state.Name,
                Country = converted_country
            };

            return output;
        }
    }
}
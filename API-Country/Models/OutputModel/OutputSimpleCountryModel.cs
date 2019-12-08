using Application.Models.Territory.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Country.Models.OutputModel {
    public class OutputSimpleCountryModel {

        public OutputSimpleCountryModel() {
            this.States = new List<OutputSimpleStateModel>();
        }

        public List<OutputSimpleCountryModel> Convert(List<Country> countries) {
            List<OutputSimpleCountryModel> output = new List<OutputSimpleCountryModel>();

            foreach(var obj in countries) {
                var country = new OutputSimpleCountryModel() {
                    Id = obj.Id,
                    Name = obj.Name,
                    IdImage = obj.UrlPicture,
                    States = new OutputSimpleStateModel().OutputStates(obj.States)
                };
                output.Add(country);
            }
            return output;
        }

        public OutputSimpleCountryModel Convert(Country country) {
            var output = new OutputSimpleCountryModel() {
                Id = country.Id,
                Name = country.Name,
                IdImage = country.UrlPicture,
                States = new OutputSimpleStateModel().OutputStates(country.States)
            };
            return output;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string IdImage { get; set; }
        public List<OutputSimpleStateModel> States { get; set; }
    }
}
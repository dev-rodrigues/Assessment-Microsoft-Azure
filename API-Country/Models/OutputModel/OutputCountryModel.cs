using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_PAISES.Models.OutputModel {
    public class OutputCountryModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdImage { get; set; }

        public List<OutputStateModel> countries(List<Country> countries) {
            List<OutputStateModel> output = new List<OutputStateModel>();
            foreach(Country country in countries) {
                OutputStateModel model = new OutputStateModel() {
                    Id = country.Id,
                    Name = country.Name,
                    IdImage = country.URLImage
                };
                output.Add(model);
            }
            return output;
        }

        public OutputStateModel country(Country country) {
            return new OutputStateModel() {
                Id = country.Id,
                Name = country.Name,
                IdImage = country.URLImage
            };
        }
    }
}
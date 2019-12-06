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

        public List<OutputCountryModel> countries(List<State> countries) {
            List<OutputCountryModel> output = new List<OutputCountryModel>();
            foreach(State country in countries) {
                OutputCountryModel model = new OutputCountryModel() {
                    Id = country.Id,
                    Name = country.Name,
                    IdImage = country.Name
                };
                output.Add(model);
            }
            return output;
        }

        public OutputCountryModel country(State country) {
            return new OutputCountryModel() {
                Id = country.Id,
                Name = country.Name,
                IdImage = country.URLImage
            };
        }
    }
}
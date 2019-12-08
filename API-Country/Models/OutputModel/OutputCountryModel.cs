using Application.Models.Territory.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_PAISES.Models.OutputModel {
    public class OutputCountryModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdImage { get; set; }

        public List<OutputStateModel> OutPutStates { get; set; }

        public OutputCountryModel() {
            OutPutStates = new List<OutputStateModel>();
        }

        public List<OutputCountryModel> countries(List<Country> countries) {
            var output = new List<OutputCountryModel>();
            foreach(var country in countries) {
                var output_country = new OutputCountryModel() {
                    Id = country.Id,
                    IdImage = country.UrlPicture,
                    Name = country.Name,
                    OutPutStates = new OutputStateModel().States(country.States)
                };
                output.Add(output_country);
            }
            return output;
        }

        public OutputCountryModel country(Country country) {
            var output = new OutputCountryModel();
            output.Id = country.Id;
            output.Name = country.Name;
            output.IdImage = country.UrlPicture;


            var states = new List<OutputStateModel>();
            foreach(var st in country.States) {
                var converted_state = new OutputStateModel() {
                    Id = st.Id,
                    Name = st.Name,
                    IdImage = st.UrlPicture
                    // PARA EVITAR REFERENCIA CICLICA ESTOU MATANDO A REFERENCIA COUNTRY DO STATE
                    //CountryModel = output
                };
                states.Add(converted_state);
            }
            output.OutPutStates = states;
            return output;
        }
    }
}
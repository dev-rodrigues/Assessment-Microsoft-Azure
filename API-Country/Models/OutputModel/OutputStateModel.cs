using Application.Models.Territory.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_PAISES.Models.OutputModel {
    public class OutputStateModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdImage { get; set; }

        public OutputCountryModel CountryModel { get; set; }

        //public List<OutputStateModel> states(List<State> states) {
        //    List<OutputStateModel> output = new List<OutputStateModel>();
        //    foreach(State state in states) {
        //        OutputStateModel model = new OutputStateModel() {
        //            Id = state.Id,
        //            Name = state.Name,
        //            IdImage = state.UrlPicture,
        //        };

        //        OutputCountryModel country = new OutputCountryModel() {
        //            Id = state.Country.Id,
        //            Name = state.Country.Name,
        //            IdImage = state.Country.UrlPicture
        //        };
        //        model.CountryModel = country;
        //        output.Add(model);
        //    }
        //    return output;
        //}

        public List<OutputStateModel> OutputStates(ICollection<State> states) {
            List<OutputStateModel> output = new List<OutputStateModel>();
            foreach(State state in states) {
                OutputStateModel model = new OutputStateModel() {
                    Id = state.Id,
                    Name = state.Name,
                    IdImage = state.UrlPicture,
                };

                OutputCountryModel country = new OutputCountryModel() {
                    Id = state.Country.Id,
                    Name = state.Country.Name,
                    IdImage = state.Country.UrlPicture
                };
                model.CountryModel = country;
                output.Add(model);
            }
            return output;
        }

        public OutputStateModel OutputState(State state) {
            var output = new OutputStateModel() {
                Id = state.Id,
                Name = state.Name,
                IdImage = state.UrlPicture
            };

            OutputCountryModel country = new OutputCountryModel() {
                Id = state.Country.Id,
                Name = state.Country.Name,
                IdImage = state.Country.UrlPicture
            };

            output.CountryModel = country;
            return output;
        }
    }
}
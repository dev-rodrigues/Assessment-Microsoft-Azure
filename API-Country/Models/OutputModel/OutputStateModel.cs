using Core.Models;
using Core.Models.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_PAISES.Models.OutputModel {
    public class OutputStateModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdImage { get; set; }

        public List<OutputStateModel> states(List<State> states) {
            List<OutputStateModel> output = new List<OutputStateModel>();
            foreach(State state in states) {
                OutputStateModel model = new OutputStateModel() {
                    Id = state.Id,
                    Name = state.Name,
                    IdImage = state.URLImage
                };
                output.Add(model);
            }
            return output;
        }

        public OutputStateModel country(State state) {
            return new OutputStateModel() {
                Id = state.Id,
                Name = state.Name,
                IdImage = state.URLImage
            };
        }
    }
}
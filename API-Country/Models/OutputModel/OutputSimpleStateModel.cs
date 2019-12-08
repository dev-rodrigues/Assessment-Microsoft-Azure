using Application.Models.Territory.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Country.Models.OutputModel {
    public class OutputSimpleStateModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdImage { get; set; }

        public List<OutputSimpleStateModel> States(ICollection<State> states) {
            List<OutputSimpleStateModel> output = new List<OutputSimpleStateModel>();
            foreach(State state in states) {
                OutputSimpleStateModel model = new OutputSimpleStateModel() {
                    Id = state.Id,
                    Name = state.Name,
                    IdImage = state.UrlPicture,
                };
                output.Add(model);
            }
            return output;
        }
    }
}
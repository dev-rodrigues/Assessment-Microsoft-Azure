using Application.Models.Territory.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_estados.Models.InputModel {
    public class InputStateModel {
        public string Name { get; set; }
        public string IdImage { get; set; }
        public int Id_Country { get; set; }

        public State CreateState(InputStateModel input) {
            return new State() {
                Name = input.Name,
                UrlPicture = SetIdImage(input.IdImage)
            };
        }

        public string SetIdImage(string id) {
            return @"https://gabrielcouto26.blob.core.windows.net/api-amigo-fotos/" + id + ".png";
        }
    }
}
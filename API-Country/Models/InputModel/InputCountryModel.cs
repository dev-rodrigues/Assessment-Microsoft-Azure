using Application.Models.Territory.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_PAISES.Models.InputModel {
    public class InputCountryModel {
        public string Name { get; set; }
        public string IdImage { get; set; }

        public Country CreateCountry(InputCountryModel input) {
            return new Country() {
                Name = input.Name,
                UrlPicture = SetIdImage(input.IdImage)
            };
        }

        public string SetIdImage(string id) {
            return @"https://gabrielcouto26.blob.core.windows.net/api-amigo-fotos/" + id + ".png";
        }
    }
}
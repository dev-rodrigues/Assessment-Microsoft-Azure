﻿using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_PAISES.Models.InputModel {
    public class InputCountryModel {
        public string Name { get; set; }
        public string IdImage { get; }

        public Country CreateCountry(InputCountryModel input) {
            return new Country() {
                Name = input.Name,
                URLImage = SetIdImage(input.IdImage)
            };
        }

        public string SetIdImage(string id) {
            return $"url".ToLower() + id + ".png";
        }
    }
}
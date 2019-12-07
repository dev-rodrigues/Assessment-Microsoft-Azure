﻿using Core.Models.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_estados.Models.InputModel {
    public class InputStateModel {
        public string Name { get; set; }
        public string IdImage { get; set; }

        public State CreateState(InputStateModel input) {
            return new State() {
                Name = input.Name,
                URLImage = SetIdImage(input.IdImage)
            };
        }

        public string SetIdImage(string id) {
            return $"url".ToLower() + id + ".png";
        }
    }
}
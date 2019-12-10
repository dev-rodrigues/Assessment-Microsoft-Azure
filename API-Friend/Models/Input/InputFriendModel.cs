using Application.Models.Friends;
using Application.Models.Territory.Countries;
using Application.Models.Territory.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Friend.Models.Input {
    public class InputFriendModel {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string BirthDate { get; set; }

        public int IdCountry { get; set; }
        public int IdState { get; set; }
        public string IdImg { get; set; }

        public static Friend CreateFriend(InputFriendModel input, Country country, State state) {
            return new Friend() {
                Name = input.Name,
                LastName = input.LastName,
                Telephone = input.Telephone,
                Email = input.Email,
                BirthDate = Convert.ToDateTime(input.BirthDate),
                Country = country,
                State = state,
                URLImg = @"https://gabrielcouto26.blob.core.windows.net/api-amigo-fotos/" + input.IdImg + ".png",
            };
        }
    }
}
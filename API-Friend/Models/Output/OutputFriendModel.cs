using Application.Models.Friends;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Friend.Models.Output {
    public class OutputFriendModel {

        public OutputFriendModel() {
            this.Country = new OutputCountryModel();
            this.State = new OutputStateModel();
            //this.Friends = new List<OutputSingleFriendModel>();
        }

        public static List<OutputFriendModel> CreateOutputFriends(List<Friend> friends) {
            var output = new List<OutputFriendModel>();

            foreach(var friend in friends) {
                var converted = CreateOutputFriend(friend);
                output.Add(converted);
            }

            return output;
        }

        public static OutputFriendModel CreateOutputFriend(Friend friend) {
            var country = new OutputCountryModel() {
                Id = friend.Country.Id,
                Name = friend.Country.Name
            };

            var state = new OutputStateModel() {
                Id = friend.State.Id,
                Name = friend.State.Name
            };

            //var localized_friends = new List<OutputSingleFriendModel>();
            //foreach(var obj in friend.Friends) {
            //    var f = new OutputSingleFriendModel() {
            //        Id = obj.Id,
            //        Name = obj.Name,
            //        LastName = obj.LastName,
            //        Email = obj.Email
            //    };
            //    localized_friends.Add(f);
            //}

            return new OutputFriendModel() {
                Id = friend.Id,
                Name = friend.Name,
                LastName = friend.LastName,
                Email = friend.Email,
                BirthDate = friend.BirthDate.ToString(),
                Telephone = friend.Telephone,
                Country = country,
                State = state,
                //Friends = localized_friends
            };
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string BirthDate { get; set; }

        public OutputCountryModel Country { get; set; }
        public OutputStateModel State { get; set; }
        //public List<OutputSingleFriendModel> Friends { get; set; }
    }
}
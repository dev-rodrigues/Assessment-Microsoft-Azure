using Application.Models.Friends;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Friend.Models.Output {
    public class OutputSingleFriendModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public static List<OutputSingleFriendModel> FriendModels(List<Friend> friends) {
            var retorno = new List<OutputSingleFriendModel>();

            foreach(var f in friends) {
                var obj = new OutputSingleFriendModel() {
                    Id = f.Id,
                    Name = f.Name,
                    LastName = f.LastName,
                    Email = f.Email
                };
                retorno.Add(obj);
            }
            return retorno;
        }
    }
}
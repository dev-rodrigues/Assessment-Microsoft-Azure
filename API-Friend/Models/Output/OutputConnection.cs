using Application.Models.Friendships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Friend.Models.Output {
    public class OutputConnection {
        public int IdConnection { get; set; }
        public int IdFriend { get; set; }
        public string Name { get; set; }
        public string SobreNome { get; set; }

        public static List<OutputConnection> Connections(List<FriendshipDTO> dTOs) {
            var retorno = new List<OutputConnection>();

            foreach(var obj in dTOs) {
                var c = new OutputConnection() {
                    IdConnection = obj.IdConnection,
                    IdFriend = obj.IdSeguido,
                    Name = obj.NomeSeguido,
                    SobreNome = obj.SobreNome
                };
                retorno.Add(c);
            }
            return retorno;
        }
    }
}
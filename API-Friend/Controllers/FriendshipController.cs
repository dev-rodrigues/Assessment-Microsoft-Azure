using API_Friend.Models.Input;
using API_Friend.Models.Output;
using Application.Models.Friendships;
using Application.Repository.Friendships;
using Application.Repository.Territory.Countries;
using Application.Repository.Territory.Friends;
using Application.Repository.Territory.States;
using Application.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.UI.WebControls;

namespace API_Friend.Controllers {

    [RoutePrefix("api/friendship")]
    public class FriendshipController : ApiController {

        private IFriend GetFriendRepository { get; }
        private IFriendship GetFriendship { get; }

        public FriendshipController() {
            this.GetFriendRepository = Locator.GetInstanceOf<FriendRepository>();
            this.GetFriendship = Locator.GetInstanceOf<FriendshipRepository>();
        }

        [HttpPost]
        public async Task<IHttpActionResult> Store(InputFriendshipModel input) {
            var seguidor = await GetFriendRepository.Find(input.IdFollower);
            var seguido = await GetFriendRepository.Find(input.IdFollowed);

            if(seguido == null || seguidor == null) {
                return BadRequest("Erro ao processar a solicitação");
            }

            if(seguido.Id == seguidor.Id) {
                return BadRequest("Erro ao processar a solicitação");
            }

            var friendship = new Friendship() {
                Follower = seguido,
                Followed = seguidor,
            };

            var saved_friendship = GetFriendship.Save(friendship);


            if(saved_friendship != null) {
                return Ok();
            }
            return BadRequest("Erro ao processar a solicitação");
        }

        [HttpGet]
        public IHttpActionResult Show(int id_user) {

            var my_friends = GetFriendship.Friends(id_user);

            if(my_friends != null) {
                var retorno = OutputConnection.Connections(my_friends);
                return Ok(retorno);
            }

            return BadRequest("Erro ao processar a solicitação");
        }

        [HttpPut]
        public async Task<IHttpActionResult> Update(int id_connection, InputFriendshipModel input) {
            var old_connection = await GetFriendship.Find(id_connection);

            var seguido = await GetFriendRepository.Find(input.IdFollowed);

            if(seguido == null || old_connection == null) {
                return BadRequest("Erro ao processar a solicitação");
            }

            if(seguido.Id == old_connection.Follower.Id) {
                return BadRequest("Erro ao processar a solicitação");
            }

            old_connection.Followed = seguido;

            var updated_connection = GetFriendship.Update(old_connection);

            if(updated_connection != null) {
                return Ok();
            }

            return BadRequest("Erro ao processar a solicitação");
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id_connection) {
            var connection = await GetFriendship.Find(id_connection);
            var apagou = await GetFriendship.Delete(connection);
            if(apagou) {
                return Ok();
            }
            return BadRequest("Erro ao processar a solicitação");
        }
    }
}
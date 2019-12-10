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

        //[HttpPut]
        //public async Task<IHttpActionResult> Update(InputFriendshipModel input) {
        //    var Followed = await GetFriendRepository.Find(input.IdFollowed);
        //    var Follower = await GetFriendRepository.Find(input.IdFollower);

        //    if(!Followed.Friends.Contains(Follower)) {
        //        return BadRequest("Erro ao processar a solicitação");
        //    }

        //    Followed.Friends.Remove(Follower);
        //    var user_updated = await GetFriendRepository.Update(Followed);

        //    if(user_updated != null) {
        //        var converted_friend = OutputFriendModel.CreateOutputFriend(user_updated);
        //        return Ok(converted_friend);
        //    }

        //    return BadRequest("Erro ao processar a solicitação");
        //}

        //[HttpDelete]
        //public async Task<IHttpActionResult> Delete(InputFriendshipModel input) {
        //    var Followed = await GetFriendRepository.Find(input.IdFollowed);
        //    var Follower = await GetFriendRepository.Find(input.IdFollower);

        //    if(!Followed.Friends.Contains(Follower)) {
        //        return BadRequest("Erro ao processar a solicitação");
        //    }

        //    Followed.Friends.Remove(Follower);
        //    var user_updated = await GetFriendRepository.Update(Followed);

        //    if(user_updated != null) {
        //        var converted_friend = OutputFriendModel.CreateOutputFriend(user_updated);
        //        return Ok(converted_friend);
        //    }

        //    return BadRequest("Erro ao processar a solicitação");
        //}
    }
}
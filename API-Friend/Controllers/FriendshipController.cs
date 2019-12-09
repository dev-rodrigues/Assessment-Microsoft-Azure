using API_Friend.Models.Input;
using API_Friend.Models.Output;
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

        public FriendshipController() {
            this.GetFriendRepository = Locator.GetInstanceOf<FriendRepository>();
        }

        [HttpPost]
        public async Task<IHttpActionResult> Store(InputFriendshipModel input) {
            var localized_follower = await GetFriendRepository.Find(input.IdFollower);
            var localized_followed = await GetFriendRepository.Find(input.IdFollowed);

            if(localized_followed == null || localized_follower == null) {
                return BadRequest("Erro ao processar a solicitação");
            }


            if(localized_followed.Id == localized_follower.Id) {
                return BadRequest("Erro ao processar a solicitação");
            }


            //if(user_updated != null) {
            //    var converted_friend = OutputFriendModel.CreateOutputFriend(user_updated);
            //    return Ok(converted_friend);
            //}
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
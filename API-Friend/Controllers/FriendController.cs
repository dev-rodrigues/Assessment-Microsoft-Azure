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

    [RoutePrefix("api/Country")]
    public class FriendController : ApiController {

        private ICountry GetCountryRepository { get; }
        private IState GetStateRepository { get; }

        private IFriend GetFriendRepository { get; }

        public FriendController() {
            this.GetCountryRepository = Locator.GetInstanceOf<CountryRepository>();
            this.GetStateRepository = Locator.GetInstanceOf<StateRepository>();
            this.GetFriendRepository = Locator.GetInstanceOf<FriendRepository>();
        }

        [HttpPost]
        public async Task<IHttpActionResult> Store(InputFriendModel inputFriend) {
            var country = await GetCountryRepository.Find(inputFriend.IdCountry);
            var state = await GetStateRepository.Find(inputFriend.IdState);

            if(country == null || state == null) {
                return BadRequest("Country or State not found");
            }

            var friend = InputFriendModel.CreateFriend(inputFriend, country, state);
            var saved_friend = await GetFriendRepository.Save(friend);
            var converted_friend = OutputFriendModel.CreateOutputFriend(saved_friend);

            if(saved_friend.Id != 0) {
                return CreatedAtRoute("DefaultApi", new { id = converted_friend.Id }, converted_friend);
            }
            return BadRequest("Erro ao processar a solicitação");
        }

        [HttpGet]
        public async Task<IHttpActionResult> Show(int id_user) {
            var localized_friend = await GetFriendRepository.Find(id_user);

            if(localized_friend != null) {
                var converted_friend = OutputFriendModel.CreateOutputFriend(localized_friend);
                return Ok(converted_friend);
            }
            return BadRequest("Erro ao processar a solicitação");
        }

    }
}
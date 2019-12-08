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

        [HttpGet]
        public IHttpActionResult Index() {
            var localized_friends = GetFriendRepository.Index();

            if(localized_friends != null) {
                var converted_friends = OutputFriendModel.CreateOutputFriends(localized_friends);
                return Ok(converted_friends);
            }

            return BadRequest("Erro ao processar a solicitação");
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

        [HttpPut]
        public async Task<IHttpActionResult> Update(int id_user, InputFriendModel inputFriend) {
            var localized_friend = await GetFriendRepository.Find(id_user);
            var country = await GetCountryRepository.Find(inputFriend.IdCountry);
            var state = await GetStateRepository.Find(inputFriend.IdState);

            if(localized_friend == null || country == null || state == null) {
                return BadRequest("Erro ao processar a solicitação");
            }

            localized_friend.Name = inputFriend.Name;
            localized_friend.LastName = inputFriend.LastName;
            localized_friend.Email = inputFriend.Email;
            localized_friend.BirthDate = Convert.ToDateTime(inputFriend.BirthDate);
            localized_friend.Country = country;
            localized_friend.State = state;

            var updated_friend = await GetFriendRepository.Update(localized_friend);
            if(updated_friend != null) {
                var converted_updated_friend = OutputFriendModel.CreateOutputFriend(updated_friend);
                return Ok(converted_updated_friend);
            }
            return BadRequest("Erro ao processar a solicitação");
        }
    }
}
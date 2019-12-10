using API_Friend.Models.Input;
using API_Friend.Models.Output;
using Application.Repository.Counts;
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

    [RoutePrefix("api/count")]
    public class CountController : ApiController {

        private IFriend GetFriendRepository { get; }
        private ICount GetFriendCount { get; }

        public CountController() {
            this.GetFriendCount = Locator.GetInstanceOf<CountRepository>();
        }

        [HttpGet]
        public async Task<IHttpActionResult> Show() {
            var total = await GetFriendCount.SumSP();
            return Ok(total);
        }
    }
}
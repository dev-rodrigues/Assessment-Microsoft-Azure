using MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class FriendController : Controller
    {
        private readonly string base_url = "http://localhost:58373";

        // GET: Country
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var amigos = new List<FriendViewModel>();
            var amg1 = new FriendViewModel();
            var amg2 = new FriendViewModel();
            amg1.Id = "1";
            amg1.Name = "Gabriel";
            amg1.LastName = "Couto";
            amg1.Email = "Gabriel@email.com";
            amg1.Tel = "123";
            amg1.BirthDate = "26/09/1996";

            amg2.Id = "2";
            amg2.Name = "Carlos";
            amg2.LastName = "Henrique";
            amg2.Email = "Carlos@email.com";
            amg2.Tel = "123";
            amg2.BirthDate = "05/10/1994";

            amigos.Add(amg1);
            amigos.Add(amg2);


            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(base_url);

            //    var response = await client.GetAsync("api/Country/Index");

            //    if (response.IsSuccessStatusCode)
            //    {
            //        var responseContent = await response.Content.ReadAsStringAsync();

            //        paises = JsonConvert.DeserializeObject<List<FriendViewModel>>(responseContent);

            //        return View(paises);
            //    }
            //}

            return View(amigos);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            var novoPais = new FriendViewModel();

            var data = new Dictionary<string, string>
            {
                {"Name", collection["Name"]},
                {"LastName", collection["LastName"] },
                {"Tel", collection["Tel"] },
                {"Email", collection["Email"] },
                {"BirthDate", collection["BirthDate"] },
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(base_url);

                using (var requestContent = new FormUrlEncodedContent(data))
                {
                    var response = await client.PostAsync("api/Friend/Store", requestContent);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            FriendViewModel amigo = new FriendViewModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(base_url);

                var response = await client.GetAsync($"api/Friend/Show?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    amigo = JsonConvert.DeserializeObject<FriendViewModel>(responseContent);

                    return View(amigo);
                }
            }

            return View();

        }

        [HttpPut]
        public async Task<ActionResult> Edit(FormCollection collection, string id)
        {
            var data = new Dictionary<string, string>
            {
                {"Name", collection["Name"]},
                {"LastName", collection["LastName"] },
                {"Tel", collection["Tel"] },
                {"Email", collection["Email"] },
                {"BirthDate", collection["BirthDate"] },
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(base_url);

                using (var requestContent = new FormUrlEncodedContent(data))
                {
                    var response = await client.PutAsync("api/Friend/Update", requestContent);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View();
                    }
                }
            }
        }


        [HttpGet]
        public async Task<ActionResult> Delete(string id)
        {
            FriendViewModel amigo = new FriendViewModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(base_url);

                var response = await client.GetAsync($"api/Friend/Show?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    amigo = JsonConvert.DeserializeObject<FriendViewModel>(responseContent);

                    return View(amigo);
                }
            }

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id, FormCollection collection)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(base_url);

                var response = await client.GetAsync($"api/Friend/Destroy?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
        }

        [HttpGet]
        public async Task<ActionResult> Details(string id)
        {
            FriendViewModel amigo = new FriendViewModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(base_url);

                var response = await client.GetAsync($"api/Friend/Show?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    amigo = JsonConvert.DeserializeObject<FriendViewModel>(responseContent);

                    return View(amigo);
                }
            }

            return View();
        }
    }
}
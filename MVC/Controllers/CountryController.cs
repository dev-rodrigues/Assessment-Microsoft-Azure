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
    public class CountryController : Controller
    {
        private readonly string base_url = "http://localhost:58373";

        // GET: Country
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var paises = new List<PaisViewModel>();
            var pais1 = new PaisViewModel();
            var pais2 = new PaisViewModel();
            pais1.Id = "1";
            pais1.Nome = "Brasil";
            pais1.FotoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/05/Flag_of_Brazil.svg/2000px-Flag_of_Brazil.svg.png";

            pais2.Id = "2";
            pais2.Nome = "Uruguai";
            pais2.FotoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fe/Flag_of_Uruguay.svg/255px-Flag_of_Uruguay.svg.png";
            paises.Add(pais1);
            paises.Add(pais2);


            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(base_url);

            //    var response = await client.GetAsync("api/Country/Index");

            //    if (response.IsSuccessStatusCode)
            //    {
            //        var responseContent = await response.Content.ReadAsStringAsync();

            //        paises = JsonConvert.DeserializeObject<List<PaisViewModel>>(responseContent);

            //        return View(paises);
            //    }
            //}

            return View(paises);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            var novoPais = new PaisViewModel();

            var data = new Dictionary<string, string>
            {
                {"Nome", collection["Nome"]},
                {"FotoUrl", collection["FotoUrl"]}
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(base_url);

                using (var requestContent = new FormUrlEncodedContent(data))
                {
                    var response = await client.PostAsync("api/Country/Store", requestContent);

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
            PaisViewModel pais = new PaisViewModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(base_url);

                var response = await client.GetAsync($"api/Country/Show?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    pais = JsonConvert.DeserializeObject<PaisViewModel>(responseContent);

                    return View(pais);
                }
            }

            return View();

        }

        [HttpPut]
        public async Task<ActionResult> Edit(FormCollection collection, string id)
        {
            var data = new Dictionary<string, string>
            {
                {"Nome", collection["Nome"]},
                {"FotoUrl", collection["FotoUrl"]}
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(base_url);

                using (var requestContent = new FormUrlEncodedContent(data))
                {
                    var response = await client.PutAsync("api/Country/Update", requestContent);

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
            PaisViewModel pais = new PaisViewModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(base_url);

                var response = await client.GetAsync($"api/Country/Show?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    pais = JsonConvert.DeserializeObject<PaisViewModel>(responseContent);

                    return View(pais);
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

                var response = await client.GetAsync($"api/Country/Destroy?id={id}");

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
            PaisViewModel pais = new PaisViewModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(base_url);

                var response = await client.GetAsync($"api/Country/Show?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    pais = JsonConvert.DeserializeObject<PaisViewModel>(responseContent);

                    return View(pais);
                }
            }

            return View();
        }

    }
}
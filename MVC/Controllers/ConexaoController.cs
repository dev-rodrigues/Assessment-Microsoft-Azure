﻿using MVC.Models;
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
    public class ConexaoController : Controller
    {
        private readonly string base_url_amigo = "http://localhost:52353";

        [HttpPost]
        public async Task<ActionResult> Index(int id_user) {

            var conexao = new IndexConexaoViewModel();

            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri(base_url_amigo);

                var response = await client.GetAsync($"api/Friendship?id_user={id_user}");

                if(response.IsSuccessStatusCode) {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    conexao.Conexoes = JsonConvert.DeserializeObject<List<ConexaoViewModel>>(responseContent);

                    Session["IdUser"] = id_user;

                }
            }

            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri(base_url_amigo);

                var response = await client.GetAsync($"api/Friend");

                if(response.IsSuccessStatusCode) {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    conexao.Friends = JsonConvert.DeserializeObject<List<FriendViewModel>>(responseContent);

                    Session["IdUser"] = id_user;

                    return View(conexao);
                }
            }
            return View("Error");
        }

        [HttpPost]
        public async Task<ActionResult> Create(int id_user) {

            string IdUser = Session["IdUser"].ToString();

            var data = new Dictionary<string, string>
            {
                {"id_seguidor", id_user.ToString()},
                {"id_seguido", IdUser}
            };

            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri(base_url_amigo);

                using(var requestContent = new FormUrlEncodedContent(data)) {
                    var response = await client.PostAsync("api/Friendship", requestContent);

                    if(response.IsSuccessStatusCode) {
                        return RedirectToAction("Index", "Amigo");
                    }
                }

            }
            return View("Error");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id_user) {
            using(var client = new HttpClient()) {

                client.BaseAddress = new Uri(base_url_amigo);

                var response = await client.DeleteAsync($"api/Friendship?id_connection={id_user}");

                if(response.IsSuccessStatusCode) {
                    return RedirectToAction("Index", "Amigo");
                } else {
                    return View("Error");
                }
            }
        }
    }
}
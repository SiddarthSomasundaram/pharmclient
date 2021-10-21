using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PharmClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PharmClient.Controllers
{
    public class ProfController : Controller
    {
        string Token = "";

        IConfiguration _config;

        private IJsonSerializer _serializer = new JsonNetSerializer();
        private IDateTimeProvider _provider = new UtcDateTimeProvider();
        private IBase64UrlEncoder _urlEncoder = new JwtBase64UrlEncoder();
        private IJwtAlgorithm _algorithm = new HMACSHA256Algorithm();
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ProfController));

        public ProfController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public async Task<ActionResult> ViewProfile()
        {

            int uid = (int)HttpContext.Session.GetInt32("userid");
            _log4net.Info("Inside Profile View of User "+uid);
            CustomerDetail c = new CustomerDetail();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44393/api/Profile/" + uid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    c = JsonConvert.DeserializeObject<CustomerDetail>(apiResponse);
                }
            }
            return View(c);
        }
        [HttpGet]
        public async Task<ActionResult> EditProfile()
        {
            CustomerDetail c = new CustomerDetail();
            int id =(int) HttpContext.Session.GetInt32("userid");
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                var res = await client.GetAsync("https://localhost:44393/api/Profile/" + id);
                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    c = JsonConvert.DeserializeObject<CustomerDetail>(result);
                }
            }
            return View(c);
        }
        [HttpGet]
        public IActionResult EditLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> EditLogin(CustomerDetail e)
        {
            //int id = (int)HttpContext.Session.GetInt32("UserId");
            //string Token = HttpContext.Request.Cookies["Token"];
            CustomerDetail receivedemp = new CustomerDetail();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                StringContent editcon = new StringContent(JsonConvert.SerializeObject(e), Encoding.UTF8, "application/json");
                var res = await client.PostAsync("https://localhost:44383/api/CustomerDetail/CustomerLogin", editcon);
                if (res.IsSuccessStatusCode)
                {

                    return RedirectToAction("EditProfile");
                        
                }
            }
            return RedirectToAction("ViewProfile");
        }
        [HttpPost]
        public async Task<ActionResult> EditProfile(CustomerDetail e)
        {
            _log4net.Info(" Profile is edited");
            CustomerDetail receivedemp = new CustomerDetail();
            using (var httpClient = new HttpClient())
            {
                int id = e.Userid;
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(e), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("https://localhost:44393/api/Profile?id=" + id, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    receivedemp = JsonConvert.DeserializeObject<CustomerDetail>(apiResponse);
                }
            }
            return RedirectToAction("ViewProfile");
        }
    }
}

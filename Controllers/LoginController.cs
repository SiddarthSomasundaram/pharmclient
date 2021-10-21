using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PharmClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PharmClient.Controllers
{
    public class LoginController : Controller
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(LoginController));
        private readonly ISession session;
        public LoginController(IHttpContextAccessor httpContextAccessor)
        {
            session = httpContextAccessor.HttpContext.Session;
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            _log4net.Info("The Login page is displayed");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(CustomerDetail c)
        {
            _log4net.Info("The Login authentication is being invoked");
            CustomerDetail cobj = new CustomerDetail();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44356/api/Login", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (apiResponse != null)
                    {
                        using (var response1 = await httpClient.PostAsync("https://localhost:44356/api/Login/CustomerDetail", content))
                        {
                            string api = await response1.Content.ReadAsStringAsync();
                            cobj = JsonConvert.DeserializeObject<CustomerDetail>(api);
                        }

                    }
                    //cobj = JsonConvert.DeserializeObject<CustomerDetail>(apiResponse);

                }
            }
            if (cobj != null)
            {
                HttpContext.Session.SetString("email", cobj.Email);
                HttpContext.Session.SetString("username", cobj.Username);
                HttpContext.Session.SetInt32("userid", cobj.Userid);
                if (cobj.Username == "Admin" && cobj.Password == "admin")
                {
                    _log4net.Info("After authentication redirected to Admin page with user id:" + c.Userid);
                    return RedirectToAction("Prodetail", "Admin");
                }
                else
                {
                    _log4net.Info("After authentication redirected to Customer page user id" + c.Userid);
                    return RedirectToAction("Productdetails", "Prod");
                }
            }
            else
            {
                _log4net.Info("Login failed, redirection remains in Login page");
                ViewBag.message = String.Format("Please Enter Correct Credentials");
                return View();
            }



        }
        [HttpGet]
        public async Task<IActionResult> Signup()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Signup([Bind("Userid,Username,Gender,Age,Address,Email,Phone,Password")] CustomerDetail user)
        {
            CustomerDetail cobj = new CustomerDetail();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44325/api/Login/Signup", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cobj = JsonConvert.DeserializeObject<CustomerDetail>(apiResponse);

                }

            }
            return RedirectToAction("Login");

        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}

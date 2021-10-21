using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PharmClient.Models;

namespace PharmClient.Controllers
{
    public class PaymentController : Controller
    {
        public async Task<IActionResult> Payment()
        {
            return View();
        }
        public IActionResult UPI()
        {
            return View();
        }
        public IActionResult Cardpayment()
        {
            return View();
        }
        public IActionResult Cod()
        {
            return View();
        }
        public IActionResult Netbanking()
        {
            return View();
        }
        public async Task<IActionResult> Paymentsuccess()
        {
            int uid = (int)HttpContext.Session.GetInt32("userid");
            AddtoCart ord = new AddtoCart();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(ord), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44374/api/Order/Paymentorder?id="+ uid, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //cartobj = JsonConvert.DeserializeObject<AddtoCart>(apiResponse);
                }
            }
            return RedirectToAction("Productdetails","Prod");
        }
    }
}

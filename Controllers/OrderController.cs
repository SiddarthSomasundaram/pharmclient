using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PharmClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PharmClient.Controllers
{
    public class OrderController : Controller
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ProdController));
        
        [HttpGet]
        public async Task<ActionResult> CancelOrder()
        {
            _log4net.Info("The delete confirmation page is displayed");
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CancelOrder(int id)
        {
            int uid = (int)HttpContext.Session.GetInt32("userid");
            _log4net.Info("The order of customer with id " + uid + " is cancel");
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44374/api/Order/DeleteCartByUserId?Userid=" + uid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Productdetails","Prod");
        }
        public async Task<IActionResult> Myorders()
        {
            _log4net.Info("The customer orders are displayed");
            int uid = (int)HttpContext.Session.GetInt32("userid");
            List<AddtoCart> OrdInfo = new List<AddtoCart>();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                //client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("https://localhost:44374/api/Order/GetCartByUserId?Userid=" + uid);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                   
                    //Storing the response details recieved from web api   
                    var OrdResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    OrdInfo = JsonConvert.DeserializeObject<List<AddtoCart>>(OrdResponse);

                }
                if (OrdInfo.Count == 0)
                {
                    _log4net.Info("no orders, then redirected to empty cart message");
                    return RedirectToAction("CancelPage", "Order");
                }
                else
                {
                    _log4net.Info("Cart has products, displaying order");
                    return View(OrdInfo);

                }

                //returning the employee list to view  
                //return View(productInfo);
            }
        }
        public async Task<IActionResult> CancelPage()
        {
            _log4net.Info("The empty cart message is displayed");
            ViewBag.Username = HttpContext.Session.GetString("username");
            return View();
        }
        

    }
}

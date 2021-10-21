using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class ProdController : Controller
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ProdController));
        public async Task<ActionResult> Productdetails()
        {
            _log4net.Info("The Product list is displayed");
            List<Product> ProductInfo = new List<Product>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                //client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("https://localhost:44329/api/Product");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    ProductInfo = JsonConvert.DeserializeObject<List<Product>>(EmpResponse);

                }
                //returning the employee list to view  
                return View(ProductInfo);
            }
        }


        public async Task<ActionResult> AddtoCart(Product pro)
        {
            _log4net.Info("The product " + pro.Productname + " has been added to the cart");
            int uid = (int)HttpContext.Session.GetInt32("userid");
            AddtoCart cartobj = new AddtoCart();
            cartobj.Userid = uid;
            cartobj.Productid = pro.Productid;
            cartobj.ProductImage = pro.ProductImage;
            cartobj.Productname = pro.Productname;
            cartobj.ProductDesc = pro.ProductDesc;
            cartobj.Price = pro.Price;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(cartobj), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44329/api/Product", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //cartobj = JsonConvert.DeserializeObject<AddtoCart>(apiResponse);
                }
            }
            return RedirectToAction("Productdetails");
        }

        public async Task<ActionResult> Cartdetails(AddtoCart atc)
        {
            _log4net.Info("The cart products are displayed");
            int uid = (int)HttpContext.Session.GetInt32("userid");
            List<AddtoCart> CartInfo = new List<AddtoCart>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                //client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("https://localhost:44329/api/Product/GetCartByUserId?Userid=" + uid);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var CartResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    CartInfo = JsonConvert.DeserializeObject<List<AddtoCart>>(CartResponse);

                }
                //returning the employee list to view  
                return View(CartInfo);

            }
        }
        
        public async Task<ActionResult> Delete(int id)
        {

            _log4net.Info("The product with id " + id + " is deleted");
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44329/api/Product?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            _log4net.Info("Product deleted redirected to Cart");
            ViewBag.Username = HttpContext.Session.GetString("username");return RedirectToAction("Cartdetails");
        }
        public async Task<ActionResult> Orderdetails()
        {
            _log4net.Info("The order details are diplayed");
            ViewBag.Username = HttpContext.Session.GetString("username");
            int uid = (int)HttpContext.Session.GetInt32("userid");
            List<AddtoCart> OrderInfo = new List<AddtoCart>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                //client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("https://localhost:44329/api/Product/GetCartByUserId?Userid=" + uid);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var OrderResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    OrderInfo = JsonConvert.DeserializeObject<List<AddtoCart>>(OrderResponse);

                }
                //returning the employee list to view  
                return View(OrderInfo);

            }
        }
    }
}

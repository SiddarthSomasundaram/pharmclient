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
    public class AdminController : Controller
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AdminController));
        public async Task<IActionResult> Prodetail()
        {
            _log4net.Info("Inside Admin Product details");
            List<Product> productInfo = new List<Product>();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                //client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("https://localhost:44373/api/Admin");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var ProdResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    productInfo = JsonConvert.DeserializeObject<List<Product>>(ProdResponse);

                }
                //returning the employee list to view  
                return View(productInfo);
            }
        }
        public ActionResult AddProduct()
        {
            _log4net.Info("Inside Admin Add Product");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(Product i)
        {
            _log4net.Info("New Product is added by Admin");
            Product it = new Product();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(i), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44373/api/Admin", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    // it = JsonConvert.DeserializeObject<Item>(apiResponse);
                }
            }
            return RedirectToAction("Prodetail");
        }
        [HttpGet]
        public async Task<ActionResult> EditProduct(int id)
        {
            _log4net.Info(" Product  " + id + " was got by Admin for edit");

            TempData["pid"]= id;
            Product e = new Product();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44373/api/Admin/GetbyId?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    e = JsonConvert.DeserializeObject<Product>(apiResponse);
                }
            }
            return View(e);
        }

        [HttpPost]
        public async Task<ActionResult> EditProduct(Product e)
        {
            _log4net.Info("Product is Edited by Admin");
            Product receivedemp = new Product();

            using (var httpClient = new HttpClient())
            {

                int id = e.Productid;
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(e), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("https://localhost:44373/api/Admin?" + id, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    receivedemp = JsonConvert.DeserializeObject<Product>(apiResponse);
                }
            }
            return RedirectToAction("Prodetail");
        }
        [HttpGet]
        public async Task<ActionResult> DeleteProduct(int id)
        {

            Product e = new Product();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44373/api/Admin?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    e = JsonConvert.DeserializeObject<Product>(apiResponse);

                }
            }
            return RedirectToAction("Prodetail");
        }
        //[HttpGet]
        //public async Task<ActionResult> DeleteProduct(int id)
        //{
        //    _log4net.Info(" Product"+ id + " was got  by Admin to delete");
        //    TempData[" pdid"] = id;
        //    Product e = new Product();
        //    using (var httpClient = new HttpClient())
        //    {
        //        using (var response = await httpClient.GetAsync("https://localhost:44373/api/Admin/GetbyId?id=" + id))
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            e = JsonConvert.DeserializeObject<Product>(apiResponse);
        //        }
        //    }
        //    return View(e);
        //}


        //[HttpPost]
        //public async Task<ActionResult> DeleteProduct(Product e)
        //{
        //    _log4net.Info(" Product is deleted by Admin");
        //    int dpid = Convert.ToInt32(TempData["pdid"]);
        //    using (var httpClient = new HttpClient())
        //    {
        //        using (var response = await httpClient.DeleteAsync("https://localhost:44373/api/Admin?id=" + dpid))
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //        }
        //    }

        //    return RedirectToAction("Prodetail");
        //}
        //[HttpGet]
        //public async Task<ActionResult> GetProductById(int id)
        //{
        //    TempData["pid"] = id;
        //    Product e = new Product();
        //    using (var httpClient = new HttpClient())
        //    {
        //        using (var response = await httpClient.GetAsync("https://localhost:44373/api/Admin/GetbyId?id=" + id))
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            e = JsonConvert.DeserializeObject<Product>(apiResponse);
        //        }
        //    }
        //    return View(e);
        //}
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;

namespace InventoryManagement.Controllers
{
    public class HomeController : Controller
    {
        private string urlParameters = null;
        public ActionResult CreateInventory()
        {
            return View();
        }
        
        //Load Inventory By Id
        public ActionResult LoadInventory(int id)
        {

            InventoryList inventory = null;

            HttpClient client = new HttpClient();
            urlParameters = "?id=" + id;
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["InventoryAPI"].ToString() + "GetInventoryById");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                // Reading Response.  
                string result = response.Content.ReadAsStringAsync().Result;
                var jsonResult = JsonConvert.DeserializeObject(result).ToString();

                inventory = JsonConvert.DeserializeObject<InventoryList>(jsonResult);
            }
            return View(inventory.Inventory[0]);
        }
        

        public class InventoryList
        {
            public List<InventoryAPI.Models.Inventory> Inventory { get; set; }
        }
    }
}
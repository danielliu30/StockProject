using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAppStock.Connector;
using WebAppStock.Models;

namespace WebAppStock.Controllers
{
    public class HomeController : Controller
    {
        ConsumeAPI _api = new ConsumeAPI();

        public async Task<IActionResult> Index()
        {
            List<StockItem> stock = new List<StockItem>();
            HttpClient client = _api.Initialize();
            HttpResponseMessage res = await client.GetAsync("api/Stock");
            
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                stock = JsonConvert.DeserializeObject<List<StockItem>>(result);
            }
            return View(stock);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}

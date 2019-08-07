using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAppStock.AdditionalData;
using WebAppStock.Connector;
using WebAppStock.Models;

namespace WebAppStock.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConsumeAPI _api;

        public HomeController(IConsumeAPI api)
        {
            _api = api;
        }

        public async Task<IActionResult> Index()
        {
            List<StockItem> stockList = await _api.GetStockList();
          
            return View(stockList);
        }

        public async Task<IActionResult> Analyze(string Id)
        {
            StockItem stock = await _api.GetIndividualStock(Id);

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

    }
}

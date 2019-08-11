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
        private readonly StockCollection _stockCollection = new StockCollection();

        public HomeController(IConsumeAPI api)
        {
            _api = api;
        }

        public async Task<IActionResult> Index()
         {
            
            _stockCollection.allStocks = await _api.GetStockList();
            _stockCollection.Xaxis = _stockCollection.allStocks.Select(stock => stock.TodaysDate).ToArray();
            _stockCollection.Yaxis = _stockCollection.allStocks.Select(stock => stock.HighValue).ToArray();

            return View(_stockCollection);
        }

        public async Task<IActionResult> Analyze(/*string Id*/)
        {
            //StockItem stock = await _api.GetIndividualStock(Id);

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

    }
}

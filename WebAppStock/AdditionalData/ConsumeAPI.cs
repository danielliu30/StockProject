using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebAppStock.AdditionalData;

namespace WebAppStock.Connector
{
    public class ConsumeAPI : IConsumeAPI
    {

        private readonly HttpClient _httpClient;
        private List<StockItem> stockList = null;
        private StockItem oneStock = null;

        public ConsumeAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:62504");
        }

        public async Task<List<StockItem>> GetStockList()
        {
            var res = await _httpClient.GetAsync("api/Stock");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                stockList = JsonConvert.DeserializeObject<List<StockItem>>(result);

            }
            return stockList;
        }

        public async Task<StockItem> GetIndividualStock(string id)
        {
            var res = await _httpClient.GetAsync($"api/Stock/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                oneStock = JsonConvert.DeserializeObject<StockItem>(result);
            }

            return oneStock;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebAppStock.AdditionalData
{
    public interface IConsumeAPI
    {
        Task<List<StockItem>> GetStockList();

        Task<StockItem> GetIndividualStock(string id);
    }
}

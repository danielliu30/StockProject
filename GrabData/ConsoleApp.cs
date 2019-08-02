using HtmlAgilityPack;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StockProcessor.StockObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Unity;
using WebAppStock;

namespace GrabData
{
    class ConsoleApp
    {
        public static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /*
         *Reads in Yahoo Finacne Page and loads an HTML file 
         */
        async static Task MainAsync(string[] args)
        {
            HttpClient client = new HttpClient();
            using (var response = await client.GetAsync("https://finance.yahoo.com/quote/%5EGSPC/history?p=%5EGSPC"))
            {
                var pageContents = await response.Content.ReadAsStringAsync();

                HtmlDocument pageRead = new HtmlDocument();
                pageRead.LoadHtml(pageContents);
                if (pageRead.ParseErrors.Count() > 0)
                {
                    //report invalid HTML
                }
                else
                {
                    ExtractData(pageRead);
                }
            }
        }

        /*
        *Extracts daily Snp500 values and updates collection
        */
        private static void ExtractData(HtmlDocument pageRead)
        {
            string connection = "mongodb://localhost";
            MongoClient client = new MongoClient(connection);
            var database = client.GetDatabase("Stock");
            var collection = database.GetCollection<StockItem>("SNP500");

            var dataList = pageRead.DocumentNode.SelectNodes("//tr[@class]");
            List<StockItem> list_timeSeriesStock = new List<StockItem>();

            dataList.RemoveAt(0);
            dataList.RemoveAt(dataList.Count - 1);
            foreach (var dailyData in dataList)
            {
                try
                {

                    collection.InsertOne(new StockItem
                    {
                        TodaysDate = dailyData.ChildNodes[0].InnerText,
                        OpeningValue = float.Parse(dailyData.ChildNodes[1].InnerText),
                        HighValue = float.Parse(dailyData.ChildNodes[2].InnerText),
                        LowValue = float.Parse(dailyData.ChildNodes[3].InnerText),
                        CloseValue = float.Parse(dailyData.ChildNodes[4].InnerText),
                        AdjClose = float.Parse(dailyData.ChildNodes[5].InnerText),
                        Volume = float.Parse(dailyData.ChildNodes[6].InnerText)

                    });

                    list_timeSeriesStock.Add(new StockItem
                    {
                        TodaysDate = dailyData.ChildNodes[0].InnerText,
                        OpeningValue = float.Parse(dailyData.ChildNodes[1].InnerText),
                        HighValue = float.Parse(dailyData.ChildNodes[2].InnerText),
                        LowValue = float.Parse(dailyData.ChildNodes[3].InnerText),
                        CloseValue = float.Parse(dailyData.ChildNodes[4].InnerText),
                        AdjClose = float.Parse(dailyData.ChildNodes[5].InnerText),
                        Volume = float.Parse(dailyData.ChildNodes[6].InnerText)

                    });

                }
                catch (Exception ex)
                {
                    //unable to create object
                }

            }
        }
    }
}

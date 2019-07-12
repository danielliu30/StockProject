using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebAppStock;
using WebAppStock.StockObject;

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
            var dataList = pageRead.DocumentNode.SelectNodes("//tr[@class]");

            List<DailySnP> list_timeSeriesStock = new List<DailySnP>();

            dataList.RemoveAt(0);
            dataList.RemoveAt(dataList.Count - 1);
            foreach (var dailyData in dataList)
            {
                try
                {
                    list_timeSeriesStock.Add(new DailySnP
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
            SnpCollection.CollectionData = list_timeSeriesStock;
        }
    }
}

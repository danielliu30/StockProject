using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebAppStock.Connector
{
    public class ConsumeAPI
    {
        public HttpClient Initialize()
        {
            var Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:62504");
            return Client;
        }
    }
}

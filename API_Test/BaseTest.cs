using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System.Collections.Generic;
using System.Net;

namespace API_Test
{
       public  class BaseTest
    {
        public RestClient client = new RestClient("https://jsonplaceholder.typicode.com");
        public RestRequest request = new RestRequest("users", Method.GET);

        public IRestResponse BaseApiTest()
        {
          
            IRestResponse response = client.Execute(request);
            return response;
            
        }
}
}

using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System.Collections.Generic;
using System.Net;


namespace API_Test
{ 
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public void Test1()
        {
            RestClient client = new RestClient("https://jsonplaceholder.typicode.com/users");
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            var content = response.Content;
            List <RootObject> users = JsonConvert.DeserializeObject<List<RootObject>>(content);


            //List<RootObject> user = new JsonDeserializer().Deserialize<List<RootObject>>(response);


            foreach (var user in users)
            
            Assert.That(user.Email, Is.Not.Empty);
            
            
        }

        [Test]
        public void Test2()
        {
            RestClient client = new RestClient("https://jsonplaceholder.typicode.com/users");
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void Test3()
        {
            RestClient client = new RestClient("https://jsonplaceholder.typicode.com");
            RestRequest request = new RestRequest("users/2", Method.GET);
            IRestResponse response = client.Execute(request);

            var content = response.Content;


            
            RootObject user = JsonConvert.DeserializeObject<RootObject>(content);

           
            Assert.Multiple(() =>
            {
                Assert.That(user.Address.Street, Is.EqualTo("Victor Plains"));
                Assert.That(user.Address.Suite, Is.EqualTo("Suite 879"));             
                Assert.That(user.Address.City, Is.EqualTo("Wisokyburgh"));
                Assert.That(user.Address.Zipcode, Is.EqualTo("90566-7771"));


            });
        }
    }

}
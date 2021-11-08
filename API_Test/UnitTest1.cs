using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System.Collections.Generic;
using System.Net;
using System.Linq;

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

            var request = new BaseTest();
            var response = request.BaseApiTest();
            //List <RootObject> users = JsonConvert.DeserializeObject<List<RootObject>>(content);


            List<RootObject> users = new JsonDeserializer().Deserialize<List<RootObject>>(response);
            


            foreach (var user in users)
            
            Assert.That(user.Email, Is.Not.Empty);
            
            
        }

        [Test]
        public void Test2()
        {
            var request = new BaseTest();
            var response = request.BaseApiTest();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void Test3()
        {
            var request = new BaseTest();
            var response = request.BaseApiTest();

            List<RootObject> users = new JsonDeserializer().Deserialize<List<RootObject>>(response);

           var output = users.Where(u => u.Email == "Shanna@melissa.tv");
          
           foreach (var u in output)
           
            Assert.Multiple(() =>
            {
                Assert.That(u.Address.Street, Is.EqualTo("Victor Plains"));
                Assert.That(u.Address.Suite, Is.EqualTo("Suite 879"));             
                Assert.That(u.Address.City, Is.EqualTo("Wisokyburgh"));
                Assert.That(u.Address.Zipcode, Is.EqualTo("90566-7771"));


            });
        }
    }

}
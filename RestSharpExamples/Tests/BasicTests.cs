using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using RestSharpExamples.DataEntities;
using System.Net;


namespace RestSharpExamples.Tests
{
    [TestFixture]
    public class BasicTests
    {
        [Test]
        public void StatusCodeTest()
        {
            // arrange
            RestClient client = new RestClient("http://api.zippopotam.us");
            RestRequest request = new RestRequest("US/80212", Method.GET);

            // act
            IRestResponse response = client.Execute(request);
            LocationResponse locationResponse =
                new JsonDeserializer().
                Deserialize<LocationResponse>(response);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(locationResponse.Places[0].State, Is.EqualTo("Colorado")); 
        }
        
        [Test]
        public void ContentTypeTest()
        {
            // arrange
            RestClient client = new RestClient("http://api.zippopotam.us");
            RestRequest request = new RestRequest("nl/3825", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.ContentType, Is.EqualTo("application/json"));
        }
    }
}

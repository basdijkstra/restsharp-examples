using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using RestSharpExamples.DataEntities;

namespace RestSharpExamples.Tests
{
    [TestFixture]
    public class DeserializationTests
    {
        [Test]
        public void CountryAbbreviationSerializationTest()
        {
            // arrange
            RestClient client = new RestClient("http://api.zippopotam.us");
            RestRequest request = new RestRequest("us/90210", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            LocationResponse locationResponse =
                new JsonDeserializer().
                Deserialize<LocationResponse>(response);

            // assert
            Assert.That(locationResponse.CountryAbbreviation, Is.EqualTo("US"));
        }

        [Test]
        public void StateSerializationTest()
        {
            // arrange
            RestClient client = new RestClient("http://api.zippopotam.us");
            RestRequest request = new RestRequest("us/12345", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            LocationResponse locationResponse =
                new JsonDeserializer().
                Deserialize<LocationResponse>(response);

            // assert
            Assert.That(locationResponse.Places[0].State, Is.EqualTo("New York"));
        }
    }
}
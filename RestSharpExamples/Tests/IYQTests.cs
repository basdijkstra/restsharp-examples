using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using RestSharpExamples.DataEntities;
using System;
using System.Net;
using System.Linq;
using System.Collections.Generic;


namespace RestSharpExamples.Tests
{
    [TestFixture]
    public class IYQTests
    {
        [Test]
        public void Get_locationResponse_Country_Shouldbe_200()
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
            Assert.That(locationResponse.Places[0].State.Equals("Colorado"));
            Assert.That(locationResponse.Places[0].StateAbbreviation.Equals("CO"));
            //Console.WriteLine(response.Content);
            Console.WriteLine(response.ErrorException.Message);


        }
    }
}

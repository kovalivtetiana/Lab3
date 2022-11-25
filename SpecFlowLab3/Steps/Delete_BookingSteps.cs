using Newtonsoft.Json.Linq;
using Lab3.Models;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;
using System.Net;
using TechTalk.SpecFlow;

namespace SpecFlowLab3.Steps
{
    [Binding]
    public class Delete_BookingSteps
    {
        private RestClient client;
        private RestResponse response;
        [When(@"call request to delete a record")]
        public void WhenCallRequestToDeleteARecord()
        {
            RestClient client = new RestClient("http://restful-booker.herokuapp.com/booking/");
            RestRequest request = new RestRequest("25538", Method.Delete);

            client.Authenticator = new HttpBasicAuthenticator("admin", "password123");

            response = client.Execute(request);
        }
        
        [Then(@"The response status code should be Created")]
        public void ThenTheResponseStatusCodeShouldBeCreated()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }
    }
}

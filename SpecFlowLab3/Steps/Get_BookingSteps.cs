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
    public class Get_BookingSteps
    {
        private RestClient client;
        private RestResponse<BookingModel> response;
        [When(@"send read booking request")]
        public void WhenSendReadBookingRequest()
        {
            RestClient client = new RestClient("http://restful-booker.herokuapp.com/booking/");
            RestRequest request = new RestRequest("", Method.Get);request.RequestFormat = DataFormat.Json;
            response = client.Execute<BookingModel>(request);
        }

        [Then(@"The response status code should be OK")]
        public void ThenTheResponseStatusCodeShouldBeOK()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}

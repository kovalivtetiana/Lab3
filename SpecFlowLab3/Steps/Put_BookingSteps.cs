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
    public class Put_BookingSteps
    {
        private RestClient client;
        private RestResponse<BookingModel> response;

        [When(@"send update booking request")]
        public void WhenSendUpdateBookingRequest()
        {
            RestClient client = new RestClient("http://restful-booker.herokuapp.com/booking/");
            RestRequest request = new RestRequest("28601", Method.Put);
            request.RequestFormat = DataFormat.Json;
            client.Authenticator = new HttpBasicAuthenticator("admin", "password123");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new BookingModel()
            {
                firstname = "Tetiana",
                lastname = "Kovaliv",
                totalprice = 200,
                depositpaid = true,
                Bookingdates = new Bookingdates()
                {
                    checkin = "2018-02-02",
                    checkout = "2019-09-09"
                },
                additionalneeds = "Breakfast"
            });
            request.AddHeader("Accept", "application/json");
            
            response = client.Execute<BookingModel>(request);

        }

        [Then(@"response status code should be OK")]
        public void ThenResponseStatusCodeShouldBeOK()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}

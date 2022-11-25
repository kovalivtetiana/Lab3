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
    public class Get_PhotoSteps
    {
        private RestClient client1;
        private RestResponse<PhotoModel> response1;
        [When(@"sending a request to read photo from id")]
        public void WhenSendingARequestToReadPhotoFromId()
        {
            RestClient client1 = new RestClient("http://picsum.photos/");
            RestRequest request1 = new RestRequest("id/10/info/", Method.Get);
            // act
            response1 = client1.Execute<PhotoModel>(request1);
        }

        [Then(@"the response status code should be OK")]
        public void ThenTheResponseStatusCodeShouldBeOK()
        {
            Assert.That(response1.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}

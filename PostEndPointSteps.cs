using NUnit.Framework;
using SpecFlowProject2.Hooks;
using System;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using TechTalk.SpecFlow;

namespace SpecFlowProject2.StepDefinitions
{
    [Binding]
    public class PostEndPointSteps
    {

        private readonly ScenarioContext _scenarioContext;

        public PostEndPointSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I prepare a new entry to be sent")]
        public void GivenIPrepareANewEntryToBeSent()
        {
            // Create original data that will be sent to the server as PostModelClass instance
            var originalData = new PostModelClass
            {
                Title = "TCS Teszt",
                Body = "Lorem Ipsum Test Text",
                userId = 123456,
                id = 101 // this is a fixed value as per the test api
            };

            // Converting original data to JSON
            string originalJSON = JsonSerializer.Serialize(originalData);

            // Create payload for POST request
            var payload = new StringContent(originalJSON, Encoding.UTF8, "application/json");
            
            // Saving previous data for further use in other steps
            _scenarioContext["originalJSON"] = originalJSON;
            _scenarioContext.Set(payload, "Payload");
        }

        [When(@"I send the new entry with POST")]
        public async Task WhenISendTheNewEntryWithPOST()
        {
            using (HttpClient client = new HttpClient())
            {
                // Post request with retrieving payload from GIVEN step
                HttpResponseMessage response = await client.PostAsync(_scenarioContext.Get<Uri>("PostURL"), (HttpContent)_scenarioContext["Payload"]);
                
                // Converting the response content to PostModelClass structure so it can be asserted in final THEN step
                var stream = await response.Content.ReadAsStreamAsync();
                PostModelClass responseJson = await JsonSerializer.DeserializeAsync<PostModelClass>(stream);

                // Saving previous data for further use in other steps
                _scenarioContext.Set(response.StatusCode, "PostResponseStatusCode1");
                _scenarioContext["responseJSON"] = responseJson;
            }
        }

        [Then(@"the request is successful")]
        public void ThenTheRequestIsSuccessful()
        {
            // Asserting POST response status code
            Assert.AreEqual(HttpStatusCode.Created, _scenarioContext.Get<HttpStatusCode>("PostResponseStatusCode1"));
        }

        [Then(@"the data on the server matches with the data that was originally sent")]
        public async Task ThenTheDataOnTheServerMatchesWithTheDataThatWasOriginallySent()
        {
            // Get original JSON from previous steps to be used as expected data
            string originalJson = _scenarioContext["originalJSON"] as string;

            // Converting response JSON to a PostModelClass instance so it can be used as actual data
            PostModelClass jsonObject = _scenarioContext["responseJSON"] as PostModelClass;

            // Convert response JSON to string
            string retrievedJson = JsonSerializer.Serialize(jsonObject);

            // Compare original data to actual data from server
            Assert.AreEqual(originalJson, retrievedJson);
        }
    }
}

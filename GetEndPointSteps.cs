using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;

namespace SpecFlowProject2.StepDefinitions
{
    [Binding]
    public class GetEndPointSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public GetEndPointSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I send a GET request to GET endpoint")]
        public async Task WhenISendAGETRequestToGETEndpoint()
        {
            using (HttpClient client = new HttpClient())
            {
                // Sending GET and saving its response as STRING
                HttpResponseMessage response = await client.GetAsync(_scenarioContext.Get<Uri>("GetURL"));
                string responseBody = await response.Content.ReadAsStringAsync();

                // Saving data for further use in other steps
                _scenarioContext.Set(responseBody, "responseBody");
                _scenarioContext.Set(response.StatusCode, "responseStatusCode");
            }
        }

        [Then(@"the GET request responds with success status code")]
        public void ThenTheGETRequestRespondsWithSuccessStatusCode()
        {
            // Asserting that GET response status is OK
            Assert.AreEqual(HttpStatusCode.OK, _scenarioContext.Get<HttpStatusCode>("responseStatusCode"));
        }

        [When(@"I evaluate all userID fields")]
        public void WhenIEvaluateAllUserIDFields()
        {
            // Retrieving and converting previous GET request's content
            string responseBody = _scenarioContext.Get<string>("responseBody");
            var jsonData = JsonConvert.DeserializeObject<dynamic>(responseBody);

            // Create new list for user IDs
            List<int> allUserID = new List<int>();

            // Iterate through the response content and save all user IDs into list above
            foreach (var field in jsonData)
            {
                allUserID.Add((int)field.userId);
            }

            // Save list for further use
            _scenarioContext["AllUserID"] = allUserID;
        }

        [Then(@"all userID field's type is INT")]
        public void ThenAllFieldsTypeIsINT()
        {
            // Retrieve previously created user ID list
            List<int> AllUserIdList = (List<int>)_scenarioContext["AllUserID"];

            // Iterate through the list and make sure all value's type are INT
            foreach (int item in AllUserIdList)
            {
                Assert.IsInstanceOf<int>(item);
            }
        }

        [When(@"I evaluate all ID fields")]
        public void WhenIevaluateallIDfields()
        {
            // Retrieving and converting previous GET request's content
            string responseBody = _scenarioContext.Get<string>("responseBody");
            var jsonData = JsonConvert.DeserializeObject<dynamic>(responseBody);

            // Create new list for IDs
            List<int> allId = new List<int>();

            // Iterate through the response content and save all IDs into list above
            foreach (var field in jsonData)
            {
                allId.Add((int)field.id);
            }

            // Save list for further use
            _scenarioContext["allIDList"] = allId;
        }

        [Then(@"all ID field's type is int")]
        public void ThenallIDfieldstypeisint()
        {
            // Retrieve previously created ID list
            List<int> allIdList = (List<int>)_scenarioContext["allIDList"];

            // Iterate through the list and make sure all value's type are INT
            foreach (int item in allIdList)
            {
                Assert.IsInstanceOf<int>(item);
            }
        }

        [When(@"I evaluate all title field")]
        public void WhenIEvaluateAllTitleField()
        {
            // Retrieving and converting previous GET request's content
            string responseBody = _scenarioContext.Get<string>("responseBody");
            var jsonData = JsonConvert.DeserializeObject<dynamic>(responseBody);

            // Create new list for titles
            List<string> allTitle = new List<string>();

            // Iterate through the response content and save all titles into list above
            foreach (var field in jsonData)
            {
                allTitle.Add((string)field.title);
            }

            // Save list for further use
            _scenarioContext["allTitleList"] = allTitle;
        }

        [Then(@"all title field's type is STRING")]
        public void ThenAllTitleFieldsTypeIsSTRING()
        {
            // Retrieve previously created title list
            List<string> allTitleList = (List<string>)_scenarioContext["allTitleList"];

            // Iterate through the list and make sure all value's type are STRING
            foreach (string item in allTitleList)
            {
                Assert.IsInstanceOf<string>(item);
            }
        }

        [When(@"I evaluate all body field")]
        public void WhenIEvaluateAllBodyField()
        {
            // Retrieving and converting previous GET request's content
            string responseBody = _scenarioContext.Get<string>("responseBody");
            var jsonData = JsonConvert.DeserializeObject<dynamic>(responseBody);

            // Create new list for bodies
            List<string> allBody = new List<string>();

            // Iterate through the response content and save all bodies into list above
            foreach (var field in jsonData)
            {
                allBody.Add((string)field.body);
            }

            // Save list for further use
            _scenarioContext["allBodyList"] = allBody;
        }

        [Then(@"all body field's type is STRING")]
        public void ThenAllBodyFieldsTypeIsSTRING()
        {
            // Retrieve previously created body list
            List<string> allBodyList = (List<string>)_scenarioContext["allBodyList"];

            // Iterate through the list and make sure all value's type are STRING
            foreach (string item in allBodyList)
            {
                Assert.IsInstanceOf<string>(item);
            }
        }

        [When(@"I evaluate the number of fields")]
        public void WhenIEvaluateTheNumberOfFields()
        {
            // Retrieving and converting previous GET request's content
            string responseBody = _scenarioContext.Get<string>("responseBody");
            var jsonData = JsonConvert.DeserializeObject<dynamic>(responseBody);

            // Set counter for fields
            int NumberOfAllFields = 0;

            // Iterate through the fields and count them
            foreach (var field in jsonData)
            {
                NumberOfAllFields++;
            }

            // Save counter for further use
            _scenarioContext.Set<int>(NumberOfAllFields, "NumberOfAllFields");
        }

        [Then(@"the total number of fields equal to (.*)")]
        public void ThenTheTotalNumberOfFieldsEqualTo(int p0)
        {
            // Get previous field counter and assert it against expected number
            Assert.AreEqual(p0, _scenarioContext.Get<int>("NumberOfAllFields"));
        }

    }
}

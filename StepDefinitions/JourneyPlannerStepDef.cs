using TFLJourneyPlanner.PageObject;

namespace TFLJourneyPlanner.StepDefinitions
{
    [Binding]
    public sealed class TFLJourneyPlannerStepDef
    {
        ScenarioContext _scenarioContext;
        JourneyPlannerHomePage journeyPlannerHomePage;
        public TFLJourneyPlannerStepDef(IObjectContainer _container)
        {
            _scenarioContext = _container.Resolve<ScenarioContext>();
            journeyPlannerHomePage = _container.Resolve<JourneyPlannerHomePage>();
        }

        [Given(@"User is on tfl\.gov\.uk home page")]
        public void GivenIAmTfl_Gov_UkHomePage() => journeyPlannerHomePage.navigateToSite();

        [Given(@"User click on accept all cookies")]
        public void GivenUserClickOnAcceptAllCookies() => journeyPlannerHomePage.AcceptCookies();

        [Given(@"User click on done Your cookie settings are saved")]
        public void GivenUserClickOnDone() => journeyPlannerHomePage.ClickCookieDone();
   
        [When(@"User enter valid location details")]
        public void WhenIEnterValidLocationAsFollows(Table table)
        {
            dynamic enterDetails = table.CreateDynamicInstance();
            journeyPlannerHomePage.validLocationDetails(enterDetails.fromLocation, enterDetails.toLocation);

        }

        [When(@"User click on plan my journey btn")]
        public void WhenUserClickOnPlanMyJourneyBtn() => journeyPlannerHomePage.clickPlanMyJourneyBtn();

        [Then(@"User is presented with the '(.*)'")]
        public void UserIsPresentedWithTheJourneyResults(string expectedValue)
        {
            var actualValue = journeyPlannerHomePage.getJourneyResultHeaderText();
            Assert.AreEqual(expectedValue, actualValue);
        }

        [When(@"User enter invalid location details")]
        public void WhenUserEnterInvalidLocationDetails(Table table)
        {
            dynamic enterDetails = table.CreateDynamicInstance();
            journeyPlannerHomePage.invalidLocationDetails(enterDetails.invalidFromLocation, enterDetails.invalidToLocation);
        }

        [Then(@"User is presented with error Message '(.*)'")]
        public void UserIsPresentedWithErrorMessage(string expectedErrorMessage)
        {
            var actualErrorMessage = journeyPlannerHomePage.getErrorMessageDisplayed();
            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
        }

        [When(@"User enter empty location as details")]
        public void WhenUserEnterEmptyLocationAsDetails(Table table)
        {
            dynamic enterDetails = table.CreateDynamicInstance();
            journeyPlannerHomePage.emptyLocationAsDetails(enterDetails.emptyFromLocation, enterDetails.emptyToLocation);
        }

        [Then(@"Error Messages displayed on From and To text field")]
        public void TErrorMessagesDisplayed(Table table)
        {
            dynamic errorterDetails = table.CreateDynamicInstance();
            Assert.Multiple(() =>
            {
                Assert.AreEqual(errorterDetails.From, journeyPlannerHomePage.getFromErrorMessage());
                Assert.AreEqual(errorterDetails.To, journeyPlannerHomePage.geToErrorMessage());
            });
        }

        [When(@"User click on change time LinkText")]
        public void WhenUserClickOnChangeTimeLinkText() => journeyPlannerHomePage.clickChangeTime();

        [When(@"User verify that (.*) is displayed")]
        public void WhenUserVerifyThatArrivingIsDisplayed(string expected)
        {
            var actual = journeyPlannerHomePage.arrivingTimeDisplayed();
            Assert.AreEqual(expected, actual);
        }

        [When(@"User click on Arriving")]
        public void WhenUserClickOnArriving() => journeyPlannerHomePage.clickArrivingTime();

        [Then(@"User is presented with the Arriving Journey time")]
        public void UserIsPresentedWithArrivingJourneyTime()
        {
            var arrivingTimeDetails = journeyPlannerHomePage.IsArrivingTimeDisplayed();
            Assert.IsTrue(journeyPlannerHomePage.IsArrivingTimeDisplayed().Equals(arrivingTimeDetails));
        }

        [When(@"User click on Edit Journey")]
        public void WhenUserClickOnEditJourney() => journeyPlannerHomePage.clickEdithJourney();

        [When(@"User enter (.*) as To to update journey")]
        public void WhenUserEnterBrentfordAsToToUpdateJourney(string value) => journeyPlannerHomePage.enterEnterToEdith(value);

        [When(@"User click on updateJourney button")]
        public void WhenUserClickOnUpdateJourneyButton() => journeyPlannerHomePage.clickUpdateJourneyBtn();

        [Then(@"User is presented with updated journey result")]
        public void UserIsPresentedWithUpdatedJourneyResult()
        {
            var upadatedJourneyDetails = journeyPlannerHomePage.IsArrivingTimeDisplayed();
            Assert.IsTrue(journeyPlannerHomePage.IsArrivingTimeDisplayed().Equals(upadatedJourneyDetails));
        }
              
    }
}
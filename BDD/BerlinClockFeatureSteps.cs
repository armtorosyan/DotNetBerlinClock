using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace BerlinClock
{
    [Binding]
    public class TheBerlinClockSteps
    {
        private readonly ITimeConverter berlinClock = new TimeConverter();
        private string theTime;
        
        [When(@"the time is ""(.*)""")]
        public void WhenTheTimeIs(string time)
        {
            theTime = time;
        }
        
        [Then(@"the clock should look like")]
        public void ThenTheClockShouldLookLike(string theExpectedBerlinClockOutput)
        {
            Assert.AreEqual(theExpectedBerlinClockOutput, berlinClock.ConvertTime(theTime));
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace TwitterScrapper
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void HashTagScrapper()
        {
            TweetsWrapper tweetsWrapper = new TweetsWrapper();
           IReadOnlyList<IWebElement> list = tweetsWrapper.getTweets("realDonaldTrump", 120);
           Assert.AreEqual(list.Count, 120);
        }
    }
}

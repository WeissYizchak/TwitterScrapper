using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterScrapper
{
    /// <summary>
    /// Managing contract with the website
    /// </summary>
    class TweetsWrapper
    {
        /// <summary>
        /// Gets a list of HTML elements of the user (AccountName) last tweets in Twitter.com
        /// </summary>
        /// <param name="AccountName">Account Url in tweeter</param>
        /// <param name="numTw">number of tweets to load</param>
        /// <returns></returns>
        public IReadOnlyList<IWebElement> getTweets(string AccountName, int numTw)
        {
            try
            {
                IWebDriver driver = new ChromeDriver();
                driver.Url = ("https://twitter.com/" + AccountName);
            
            //Increases the scoop
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            while (driver.FindElements(By.ClassName("js-stream-item")).Count < numTw)
            {
                jse.ExecuteScript("window.scrollBy(0,10000)");
            }

            List<IWebElement> list = new List<IWebElement>(driver.FindElements(By.ClassName("js-stream-item")));
            
            while (list.Count > numTw)
                list.RemoveAt(list.Count - 1);
            return list;
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: you have a problem in the driver!!");
            }
        }
    }

    /// <summary>
    /// Implement the functions of the IDataAnalyzing interface by selenium
    /// </summary>
    class TweetsInfo : IDataAnalyzing
    {
        IReadOnlyList<IWebElement> listOfTweets;

        /// <summary>
        /// Constractor - initilize with the 100 last twest By defult
        /// </summary>
        public TweetsInfo(string AccountName)
        {
            UpdateTweets(AccountName,100);
        }

        /// <summary>
        /// Updating the list of latest tweets by numTw 
        /// </summary>
        /// <param name="numTw">number of tweets</param>
        public void UpdateTweets(string AccountName,int numTw)
        {
            listOfTweets = new TweetsWrapper().getTweets(AccountName, numTw);
        }

        /// <summary>
        /// gets all hashtags in the tweets
        /// </summary>
        /// <returns>list (string) of the hashtags</returns>
        public List<string> GetHashtags()
        {
            List<string> hashtagList = new List<string>();
            foreach (IWebElement el in listOfTweets)
            {
                try
                {
                    hashtagList.Add(el.FindElement(By.ClassName("twitter-hashtag")).FindElement(By.TagName("b")).Text);
                }
                catch (Exception e)
                { }

            }
            return hashtagList;
        }

        /// <summary>
        /// Gets all mantion of the tweets
        /// </summary>
        /// <returns>list (string) of mention</returns>
        public List<string> GetMentions()
        {
            List<string> mentionList = new List<string>();
            foreach (IWebElement el in listOfTweets)
            {
                try
                {
                    mentionList.Add(el.FindElement(By.ClassName("twitter-atreply")).FindElement(By.TagName("b")).Text);
                }
                catch (Exception e)
                { }

            }
            return mentionList;
        }

        /// <summary>
        /// gets and Provides the details of Statistics class by selenium
        /// </summary>
        /// <returns>Statistic class</returns>
        public TweetsStatistics GetStatistics()
        {
            return new TweetsStatistics(listOfTweets);
        }
    }
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterScrapper
{
    /// <summary>
    /// Holds all the data of the tweets
    /// </summary>
    public class TweetsInformation
    {
        IDataAnalyzing instance;
        public string Name { get; set; }
        public List<string> HashtagList;
        public List<string> MentionList;
        public TweetsStatistics statistics;

        /// <summary>
        /// Constractor - initilize the details
        /// </summary>
        /// <param name="AccountName">resource in Tweeter.com</param>
        public TweetsInformation(string AccountName = "realDonaldTrump")
        {
            instance = Factory.GetDataAnalyiz("selenium", AccountName);
            Name = AccountName;
            _loadeData();
        }

        /// <summary>
        /// Loads Tweets from the site again
        /// </summary>
        /// <param name="numTw">number of tweets to load</param>
        public void updateNewTweets(int numTw)
        {
            instance.UpdateTweets(Name ,numTw);
            _loadeData();
        }

        /// <summary>
        /// lode the data from the Tweets
        /// </summary>
        private void _loadeData()
        {
            HashtagList = instance.GetHashtags();
            MentionList = instance.GetMentions();
            statistics = instance.GetStatistics();
        }
    }

    /// <summary>
    /// Generates classes for different information sources
    /// </summary>
    class Factory
    {
        static public IDataAnalyzing GetDataAnalyiz(string str, string AccountName)
        {
            switch (str)
            {
                case "selenium":
                    return new TweetsInfo(AccountName);
                default:
                    throw new Exception();
            }
        }
    }

    
}



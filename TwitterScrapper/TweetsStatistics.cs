using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TwitterScrapper
{
    public class TweetsStatistics
    {
        private IReadOnlyList<IWebElement> listOfTweets;

        public int MaxTweet { get; set; }
        public int MinTweet { get; set; }


        public TweetsStatistics(IEnumerable<IWebElement> collection)
        {
            int min = int.MaxValue;
            int max = int.MinValue;
            foreach (IWebElement el in collection)
            {
                try
                {
                    string tw = el.FindElement(By.TagName("p")).Text;

                    char[] separetor = { ' ', '\t', '\n' };
                    int wordsCounter = tw.Split(separetor, StringSplitOptions.RemoveEmptyEntries).Length;
                    if (wordsCounter > max)
                    {
                        max = wordsCounter;
                    }
                    if (wordsCounter < min)
                    {
                        min = wordsCounter;
                    }
                }
                catch (Exception e)
                { }

            }
            MaxTweet = max;
            MinTweet = min;
        }
    }
}
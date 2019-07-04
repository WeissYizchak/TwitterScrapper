using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterScrapper
{
    interface IDataAnalyzing
    {
        void UpdateTweets(string AccountName, int numTw);
        List<string> GetHashtags();
        List<string> GetMentions();
        TweetsStatistics GetStatistics();
    }

}


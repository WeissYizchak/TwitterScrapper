using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterScrapper;
namespace mainProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            TweetsInformation trampTweets = new TweetsInformation();

            Console.WriteLine("---------Tweets details---------");
            Console.WriteLine("AccountName: " + trampTweets.Name);
            int i = 1;

            Console.WriteLine("---------Hashtags---------");
            foreach (string hashtag in trampTweets.HashtagList)
            {
                Console.WriteLine(i + " " + hashtag);
                i++;
            }
            i = 0;
            Console.WriteLine("---------mentions---------");
            foreach (string mention in trampTweets.MentionList)
            {
                Console.WriteLine(i + " " + mention);
                i++;
            }

            Console.WriteLine("The longest tweet is " + trampTweets.statistics.MaxTweet + " letters");
            Console.WriteLine("The shortest tweet is " + trampTweets.statistics.MinTweet + " letters");
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishExam.Models
{
    public class GetPath
    {
       
       public List<string> ReturnXpaths()
        {
            List<string> xpath = new List<string>();
            xpath.Add("//*[@id='app-root']/div/div[3]/div/div/div[2]/div[1]/div/div[1]/div[1]/div[1]/div/ul/li[2]/a[2]/h2");
            xpath.Add("//*[@id='app-root']/div/div[3]/div/div/div[2]/div[1]/div/div[1]/div[1]/div[2]/div/ul/li[2]/a[2]/h2");
            xpath.Add("//*[@id='app-root']/div/div[3]/div/div/div[2]/div[1]/div/div[1]/div[2]/div[1]/div[1]/div/ul/li[2]/a[2]/h2");
            xpath.Add("//*[@id='app-root']/div/div[3]/div/div/div[2]/div[1]/div/div[1]/div[2]/div[1]/div[2]/div/ul/li[2]/a[2]/h2");
            xpath.Add("//*[@id='app-root']/div/div[3]/div/div/div[2]/div[1]/div/div[1]/div[2]/div[2]/div/ul/li[2]/a[2]/h2");

            return xpath;
        }

        public List<string> ReturnContentOfLinks()
        {
            List<string> contentoflink = new List<string>();
            contentoflink.Add("//*[@id='app-root']/div/div[3]/div/div/div[2]/div[1]/div/div[1]/div[1]/div[1]/div/ul/li[2]/a[2]");
            contentoflink.Add("//*[@id='app-root']/div/div[3]/div/div/div[2]/div[1]/div/div[1]/div[1]/div[2]/div/ul/li[2]/a[2]");
            contentoflink.Add("//*[@id='app-root']/div/div[3]/div/div/div[2]/div[1]/div/div[1]/div[2]/div[1]/div[2]/div/ul/li[2]/a[1]");
            contentoflink.Add("//*[@id='app-root']/div/div[3]/div/div/div[2]/div[1]/div/div[1]/div[2]/div[2]/div/ul/li[2]/a[2]");
            contentoflink.Add("//*[@id='app-root']/div/div[3]/div/div/div[2]/div[1]/div/div[1]/div[2]/div[2]/div/ul/li[2]/a[2]");

            return contentoflink;
        }

        public string ReturnContent()
        {
            string content = "//*[@id='main-content']/article/div[2]/div/div[1]/div[1]/div[1]/div/p[1]";
           
            return content;
        }

       
    }
}

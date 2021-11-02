using EnglishExam.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EnglishExam.Helpers
{
    public class WiredCrawler
    {
        private Uri Uri;
        private string getHtml;
        public List<NewsModel> GetLast5News()
        {
            string url = "https://www.wired.com/most-recent/";
            try
            {
                Uri = new Uri(url);
            }
            catch (UriFormatException)
            {
                throw new Exception("Format Hatası");
            }
            catch (ArgumentNullException)
            {
                throw new Exception("Argüman Boş");
            }

            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;

            try
            {
                getHtml = webClient.DownloadString(Uri);
            }
            catch (WebException)
            {
                throw new Exception("Web Excepion Hatası");
            }
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(getHtml);
            List<NewsModel> newsList = new List<NewsModel>();
            for (int i = 1; i <= 5; i++)
            {
                var startXPath = "//*[@id='app-root']/div/div[3]/div/div[2]/div/div[1]/div/div/ul/li[" + i + "]";
                var news = new NewsModel();
                news.Title = doc.DocumentNode.SelectSingleNode(startXPath + "/div/a/h2").InnerHtml;
                news.To = doc.DocumentNode.SelectSingleNode(startXPath + "/div/a").GetAttributeValue("to", "");
                news.OrderNo = i;
              //  news = GetContent(news);
                newsList.Add(news);
            }
            return newsList;
        }
        public string GetContent(string to)
        {
            string url = "https://www.wired.com" + to;
            try
            {
                Uri = new Uri(url);
            }
            catch (UriFormatException)
            {
                throw new Exception("Format Hatası");
            }
            catch (ArgumentNullException)
            {
                throw new Exception("Argüman Boş");
            }

            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;

            try
            {
                getHtml = webClient.DownloadString(Uri);
            }
            catch (WebException)
            {
                throw new Exception("Web Excepion Hatası");
            }

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(getHtml);
            if (to.Contains("story"))
            {
                return doc.DocumentNode.SelectSingleNode("//*[@id='main-content']/article/div[2]/div/div[1]/div[1]/div[1]/div/p[1]").InnerText;
            }
            else
            {
                return doc.DocumentNode.SelectSingleNode("//*[@id='main-content']/article/div[2]/div[1]/div[1]/div[1]/div/div[1]/div/p[1]").InnerText;

            } 
        }
    }
}

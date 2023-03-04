using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace webscraping
{
    public class Quote
    {
        public string? Text { get; set; }
        public string? Author { get; set; }
        public override string ToString()
        {
            return Author + " says, " + Text;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://quotes.toscrape.com/js");
            var quotes = new List<Quote>();


            var quoteContainer = driver.FindElements(By.CssSelector("div.quote"));
            foreach (var item in quoteContainer)
            {

                Quote quote = new()
                {
                    Text = item.FindElement(By.CssSelector("span.text")).Text,
                    Author = item.FindElement(By.CssSelector(".author")).Text
                };
                quotes.Add(quote);


                Console.WriteLine(quote.ToString());
            }
        }
    }
}

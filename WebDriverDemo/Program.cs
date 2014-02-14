using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;

namespace WebDriverDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Fire up FireFox
            //IWebDriver driver = new FirefoxDriver();
            //driver.Url = "http://www.apple.com";

            //// Fire up IE
            //IWebDriver driver = new InternetExplorerDriver(@"C:\libraries\");
            //driver.Url = "http://www.apple.com";

            // Fire up Chrome
            IWebDriver driver = new ChromeDriver(@"C:\libraries\");
            driver.Url = "http://www.google.com";

            var searchBox = driver.FindElement(By.Id("gbqfq"));
            searchBox.SendKeys("pluralsight");

            //the auto populated search box was getting in front of the images link
            //so a click on search is one way to clear it. 
            var searchButton = driver.FindElement(By.ClassName("gbqfb"));
            searchButton.Click();

            // Manual Delay of up to 10 seconds
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            //var imagesLink = driver.FindElements(By.ClassName("q qs"))[0];
            var imagesLink = driver.FindElements(By.LinkText("Images"))[0];
            imagesLink.Click();

            //// This was how the example did it. 
            //var ul = driver.FindElement(By.ClassName("rg_ul"));
            //var firstImageLink = ul.FindElements(By.TagName("a"))[0];
            //firstImageLink.Click();
            var firstImage = driver.FindElement(By.ClassName("rg_i"));
            firstImage.Click(); // Will this way break if the first image changes?
            
        }
    }
}

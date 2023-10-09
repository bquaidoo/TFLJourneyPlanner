
namespace TFLJourneyPlanner.Extension
{
    public static class CustomExtension
    {
        
        /// This method allow to click an element via javascript
   
        
        public static void ClickViaJs(this IWebElement element, IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            element.Click();
        }
      
        /// This method allows for scrolling into view and enter text
        
        public static void EnterText(this IWebElement element, IWebDriver driver, string value)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            element.SendKeys(value);
        }
       
        //public static void EnterTextViaJs(this IWebElement element, IWebDriver driver, string value)
        //{
        //    Thread.Sleep(TimeSpan.FromSeconds(1));
        //    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].sendkeys();", element);
        //    element.SendKeys(value);
        //}
        
        /// This method allows to wait for element.
        
        public static void WaitFor(this IWebDriver driver, int timeOut)
        {
            Thread.Sleep(TimeSpan.FromSeconds(timeOut));
        } 
        public static void WaitUntil(this IWebDriver driver, int timeOut)
        {
            Thread.Sleep(TimeSpan.FromSeconds(timeOut));
        }

      
        /// This method allows to wait for element.
       
        public static void MilliSec(this IWebDriver driver, int timeOut)
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(timeOut));
        }

      
        /// This method allows to wait for element.
        /// </summary>
       
        public static void Implicit(this IWebDriver driver, int timeOut)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeOut);
        }

      
        /// This method allows to wait untill the element is located
       
        public static IWebElement FindThisElement(this IWebDriver driver, By by)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            return wait.Until(x => x.FindElement(by));
        }

        /// This method allows to Page Load Complete before action is perfomed

        public static void Sleep(int time) => Thread.Sleep(TimeSpan.FromSeconds((int)time));
            //public static void PageLoadComplete(IWebDriver driver, int time)
            //{
            //    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //    for (int wait = 0; wait < 30; wait++)
            //    {
            //        try
            //        {
            //            CustomExtension.Sleep(1);
            //        }
            //        catch (ThreadInterruptedException) { }
            //        if (js.ExecuteScript("return document.readyState").Equals("complete"))
            //            break;
            //    }
            //}
        
       
    }
}
using OpenQA.Selenium;

namespace DemoAutomation.PageObjects.Cars
{
    public class MainCarSettingsSection : Page
    {
        private IWebElement CarStatusSelect => driver.FindElement(By.Name("carstatus"));

        private IWebElement CarTypeDropDown => driver.FindElement(By.Id("s2id_autogen21"));

        private IWebElement IsFeaturedSelect => driver.FindElement(By.Id("isfeatured"));

        private IWebElement FeaturedFromDateField => driver.FindElement(By.Name("ffrom"));

        private IWebElement FeaturedToDateField => driver.FindElement(By.Name("fto"));
        
    }
}
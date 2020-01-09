using OpenQA.Selenium;

namespace DemoAutomation.PageObjects
{
    public class PhpTravelsAdminLoginPage : Page
    {
        private IWebElement EmailField => driver.FindElement(By.Name("email"));

        private IWebElement PasswordField => driver.FindElement(By.Name("password"));

        public AdminConsole LogInAsAdmin()
        {
            TypeEmail(Config.CurrentConfig.Login);
            TypePassword(Config.CurrentConfig.Password);
            SubmitLogInForm();
            return new AdminConsole();
        }

        private void TypeEmail(string email) => EmailField.SendKeys(email);

        private void TypePassword(string password) => PasswordField.SendKeys(password);

        private void SubmitLogInForm() => PasswordField.Submit();
    }
}
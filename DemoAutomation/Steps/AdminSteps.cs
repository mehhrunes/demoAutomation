using DemoAutomation.PageObjects;

namespace DemoAutomation.Steps
{
    public static class AdminSteps
    {
        public static AdminConsole LogInAsAdmin() => new PhpTravelsAdminLoginPage().LogInAsAdmin();
    }
}
using OpenQA.Selenium;

namespace SeleniumCSharp.locators
{
    public static class LoginPageLocators
    {
        public static readonly By UsernameInput = By.Id("id_email");
        public static readonly By PasswordInput = By.Id("id_senha");
        public static readonly By LoginButton = By.CssSelector("button[type='submit']");
        public static readonly By btnModifyPassword = By.CssSelector(".continue-login > button:nth-child(0)");
        public static readonly By btnNoModifyPassword = By.CssSelector(".continue-login > button:nth-child(1)");
        public static readonly By SelectPlugin = By.Id("select-cli");
        public static readonly By btnHTML5Virtualizer = By.CssSelector("button[value='TSPLUS']");
        public static readonly By btnRemoteAppVirtualizer = By.CssSelector("button[value='TSPLUS_REMOTE_APP']");
        public static readonly By canvasApplications = By.Id("JWTS_myCanvas");
    }
}
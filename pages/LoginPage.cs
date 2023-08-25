using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace SeleniumCSharp.pages;

public class LoginPage : BasePage
{
    private new IWebDriver Driver;

    public LoginPage(IWebDriver driver) : base(driver)
    {
        Driver = driver;
    }

    public override void GoTo()
    {
        Driver.Navigate().GoToUrl("https://piloto.skyinone.net/user");
    }

    public override bool AssertURL()
    {
        return Driver.Url.Contains("user");
    }

    public override bool AssertTitle()
    {
        return Driver.Title.Contains("Piloto | Login");
    }

    public override void ClickElement(By locator)
    {
        Driver.FindElement(locator).Click();
    }

    public override void EnterText(By locator, string text)
    {
        Driver.FindElement(locator).SendKeys(text);
    }

    public void SelectByValue(By locator, string value)
    {
        IWebElement dropdown = Driver.FindElement(locator);
        var select = new SelectElement(dropdown);
        select.SelectByValue(value);
    }

    public void SelectByText(By locator, string text)
    {
        IWebElement dropdown = Driver.FindElement(locator);
        var select = new SelectElement(dropdown);
        select.SelectByText(text);
    }
}

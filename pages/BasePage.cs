using OpenQA.Selenium;
using SeleniumCSharp.utils;

namespace SeleniumCSharp.pages;


/// <summary>
/// BasePage class for all subsequent pages
/// </summary>
public abstract class BasePage
{
    protected IWebDriver Driver;
    public string? username;
    public string? password;

    public BasePage(IWebDriver driver)
    {
        DotEnv.Load();
        this.username = Environment.GetEnvironmentVariable("USERNAME");
        this.password = Environment.GetEnvironmentVariable("PASSWORD");
        Driver = driver;
    }

    public abstract void GoTo();
    public abstract bool AssertTitle();
    public abstract bool AssertURL();
    public abstract void ClickElement(By locator);
    public abstract void EnterText(By locator, string text);
}

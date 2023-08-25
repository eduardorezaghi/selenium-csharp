using OpenQA.Selenium;
using Xunit;
using SeleniumCSharp.pages;
using SeleniumCSharp.locators;
using FluentAssertions;
using OpenQA.Selenium.Firefox;
using SeleniumCSharp.utils;

namespace SeleniumCSharp;

public class Tests : IClassFixture<FirefoxDriverFixture>
{
    private FirefoxDriver driver;
    private LoginPage loginPage;


    public Tests(FirefoxDriverFixture fixture) {
        // Arrange
        driver = fixture.webDriver;
        loginPage = new LoginPage(driver);
    }

    [Fact]
    public void LoginTest() {
        loginPage.GoTo();
        loginPage.AssertURL();

        loginPage.AssertTitle();

        loginPage.EnterText(LoginPageLocators.UsernameInput, loginPage.username);
        loginPage.EnterText(LoginPageLocators.PasswordInput, loginPage.password);
        driver.FindElement(LoginPageLocators.PasswordInput).GetAttribute("value").Should().Be("PilotSky@456");
        loginPage.ClickElement(LoginPageLocators.LoginButton);
    }

    [Fact]
    public void HTML5PluginTest() {
        this.LoginTest();

        IWebElement divElement = driver.FindElement(By.ClassName("divTextoPrincipal"));
        if (divElement.Text.Contains("Your password will expire")) {
            loginPage.ClickElement(LoginPageLocators.btnNoModifyPassword);
        }

        loginPage.SelectByValue(LoginPageLocators.SelectPlugin, "2268453f-c7f9-4184-9416-37eb8adc8f5a");
        driver.FindElement(LoginPageLocators.SelectPlugin)
            .GetAttribute("value").Should().Be("2268453f-c7f9-4184-9416-37eb8adc8f5a");

        loginPage.ClickElement(By.CssSelector("button[type='submit']"));


        IWebElement chooseVirtualizerMessage = driver.FindElement(By.ClassName("chooseVirtualizerMessage"));
        if (chooseVirtualizerMessage.GetAttribute("innerText").Contains("Choose")) {
            loginPage.ClickElement(LoginPageLocators.btnHTML5Virtualizer);
        }

        // Add a wait here to wait for the canvas to load
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);


        IWebElement canvas = driver.FindElement(LoginPageLocators.canvasApplications);
        Thread.Sleep(10000);
        canvas.Displayed.Should().BeTrue();
    }

}

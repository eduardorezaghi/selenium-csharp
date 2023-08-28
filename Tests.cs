using OpenQA.Selenium;
using Xunit;
using SeleniumCSharp.pages;
using SeleniumCSharp.locators;
using FluentAssertions;
using OpenQA.Selenium.Firefox;
using SeleniumCSharp.utils;

namespace SeleniumCSharp;

public class Tests : IClassFixture<ChromeDriverFixture>
{
    private IWebDriver driver;
    private LoginPage loginPage;


    public Tests(ChromeDriverFixture fixture) {
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
        driver.FindElement(LoginPageLocators.PasswordInput)
            .GetAttribute("value").Should().Be(loginPage.password);
        loginPage.ClickElement(LoginPageLocators.LoginButton);
    }

    [Fact]
    public void HTML5PluginTest() {
        this.LoginTest();

        // IWebElement divElement = driver.FindElement(By.ClassName("divTextoPrincipal"));
        // if (divElement.Text.Contains("Your password will expire")) {
        //     loginPage.ClickElement(LoginPageLocators.btnNoModifyPassword);
        // }

        loginPage.SelectByValue(LoginPageLocators.SelectPlugin, "2268453f-c7f9-4184-9416-37eb8adc8f5a");
        driver.FindElement(LoginPageLocators.SelectPlugin)
            .GetAttribute("value").Should().Be("2268453f-c7f9-4184-9416-37eb8adc8f5a");

        loginPage.ClickElement(By.CssSelector("button[type='submit']"));


        IWebElement chooseVirtualizerMessage = driver.FindElement(By.ClassName("chooseVirtualizerMessage"));
        if (chooseVirtualizerMessage.GetAttribute("innerText").Contains("Escolha")) {
            loginPage.ClickElement(LoginPageLocators.btnHTML5Virtualizer);
        }

        // Add a wait here to wait for the canvas to load
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

        IWebElement canvas = driver.FindElement(LoginPageLocators.canvasApplications);
        canvas.Displayed.Should().BeTrue();
    }

    [Fact]
    public void networkTest() {
        var handler = new NetworkResponseHandler();
        handler.ResponseMatcher = httpresponse => true;

        INetwork networkInterceptor = driver.Manage().Network;

        networkInterceptor.AddResponseHandler(handler);
        networkInterceptor.StartMonitoring().Wait();
        driver.Navigate().GoToUrl("https://piloto.skyinone.net/user");
        loginPage.EnterText(LoginPageLocators.UsernameInput, loginPage.username);
        loginPage.EnterText(LoginPageLocators.PasswordInput, loginPage.password);
        loginPage.ClickElement(LoginPageLocators.LoginButton);
        networkInterceptor.StopMonitoring().Wait();
    }

    [Fact]
    public void TestOpenNotepad() {
    }
}

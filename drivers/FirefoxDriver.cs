using OpenQA.Selenium.Firefox;
using Xunit;

public class FirefoxDriverFixture : IClassFixture<FirefoxDriver>, IDisposable
{
    public FirefoxDriver webDriver { get; private set; }

    public FirefoxDriverFixture()
    {
        webDriver = new FirefoxDriver();
        webDriver.Manage().Window.Maximize();
    }

    public void Dispose()
    {
        Console.WriteLine("Disposing of FirefoxDriver");
        webDriver.Quit();
    }
}
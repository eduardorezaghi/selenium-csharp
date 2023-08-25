using OpenQA.Selenium.Chrome;
using Xunit;

public class ChromeDriverFixture : IClassFixture<ChromeDriver>, IDisposable
{
    public ChromeDriver webDriver { get; private set; }

    public ChromeDriverFixture()
    {
        webDriver = new ChromeDriver();
        webDriver.Manage().Window.Maximize();
    }

    public void Dispose()
    {
        Console.WriteLine("Disposing of ChromeDriver");
        webDriver.Quit();
    }
}
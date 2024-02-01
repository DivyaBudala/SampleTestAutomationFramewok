using SampleTestAutomationFramework.FrameworkUtilities;
using SampleTestAutomationFramework.Drivers;
using SampleTestAutomationFramework.PageObjects;

namespace SampleTestAutomationFramework.PageObjects
{
    [Binding]
    public sealed class HomePage
    {
        public static readonly By AddToCart = By.XPath("//main[@id='main']//ul//a[text()='Add to cart']");
        public static readonly By ViewCart = By.XPath("//main[@id='main']//ul//a[text()='View cart']");

        /******* Page name for reporting **********/
        public static readonly string PageName = "Home Page";

        /**** Field names for reporting ****/
        public static readonly string AddToCartButton = "ADD TO CART";
        public static readonly string ViewCartButton = "VIEW CART";
    }
}

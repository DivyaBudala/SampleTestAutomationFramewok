namespace SampleTestAutomationFramework.PageObjects
{
    [Binding]
    public sealed class CartPage
    {
        public static readonly By ProductRows = By.XPath("//div[@id='primary']//form/table/tbody/tr");
        public static readonly By ProductPrice = By.XPath("./td[@class='product-price']/span");
        public static readonly By ProductRemove = By.XPath("./td[@class='product-remove']/a[text()='×']");

        public static IWebElement? LowestPriceProduct;
        public static IWebElement? HighestPriceProduct;

        /******* Page name for reporting **********/
        public static readonly string PageName = "Cart Page";


        /**** Field names for reporting ****/
        public static readonly string ProductRowsInTable = "Product Rows";
        public static readonly string ProductPriceColumn = "Product Price";
        public static readonly string ProductRemoveButton = "Remove Button";
        public static readonly string LowestPriceProductElement = "Lowest Price Product Element";
        public static readonly string HighestPriceProductElement = "Highest Price Product Element";

    }
}

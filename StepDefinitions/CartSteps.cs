using SampleTestAutomationFramework.FrameworkUtilities;
using SampleTestAutomationFramework.Drivers;
using SampleTestAutomationFramework.PageObjects;
using FluentAssertions.Equivalency;
using FluentAssertions.Primitives;
using AngleSharp.Text;

namespace SampleTestAutomationFramework.StepDefinitions
{
    [Binding]
    public sealed class CartSteps
    {
        private IWebDriver _driver;        
        ControlFunctions _ctrlFunc;
        WebDriverUtil _driverUtil;

        public CartSteps(DriverFactory driverFactory, ControlFunctions ctrlFunc, WebDriverUtil driverUtil)
        {
            _driver = driverFactory.GetWebDriver();
            _ctrlFunc = ctrlFunc;
            _driverUtil = driverUtil;
        }
        
        [Then(@"I find total four items listed in my cart")]
        public void ThenIFindTotalFourItemsListedInMyCart()
        {
            List<IWebElement> products = _ctrlFunc.FindMultipleElements(CartPage.ProductRows, 10, CartPage.ProductRowsInTable);
            
            //Verify there are four items in the cart except the total row
            BooleanAssertions.Equals(products.Count() - 1, 4);            
        }

        [When(@"I search for lowest price item")]
        public void WhenISearchForLowestPriceItem()
        {
            List<IWebElement> products = _ctrlFunc.FindMultipleElements(CartPage.ProductRows, 10, CartPage.ProductRowsInTable);
            _driverUtil.WaitFor(2000, CartPage.ProductRowsInTable, CartPage.PageName);

            CartPage.LowestPriceProduct = GetLowestPriceItem(products);
        }

        [When(@"I am able to remove the lowest price item from my cart")]
        public void WhenIamAbleToRemoveTheLowestPriceItemFromMyCart()
        {
            _ctrlFunc.ScrollInToView(CartPage.LowestPriceProduct, 10, CartPage.LowestPriceProductElement);
            _driverUtil.WaitFor(2000, CartPage.ProductRowsInTable, CartPage.PageName);
            _ctrlFunc.Click(CartPage.LowestPriceProduct.FindElement(CartPage.ProductRemove),10,CartPage.ProductRemoveButton);
            _driverUtil.WaitFor(2000, CartPage.ProductRowsInTable, CartPage.PageName);            
        }

        [Then(@"I am able to verify three items in my cart")]
        public void ThenIamAbleToVerifyThreeItemsInMyCart()
        {
            _driverUtil.WaitFor(2000, CartPage.PageName, CartPage.PageName);

            List<IWebElement> products = _ctrlFunc.FindMultipleElements(CartPage.ProductRows, 10, CartPage.ProductRowsInTable);

            //Verify there are four items in the cart except the total row
            BooleanAssertions.Equals(products.Count() - 1, 3);
        }

        /// <summary>
        ///  Function to identify the lowest Price product in the Cart   
        /// </summary>
        /// <param name="products"></param>
        /// <returns>A WebElement for lowest priced product in the Cart</returns>
        /// <exception cref="Exception"></exception>
        private IWebElement GetLowestPriceItem(List<IWebElement> products)
        {

            _ctrlFunc.ScrollInToView(products[0], 10, CartPage.ProductPriceColumn);

            //Initialize lowest price product to the first product in the list
            float lowest = float.Parse(products[0].FindElement(CartPage.ProductPrice).Text.ReplaceFirst("$", string.Empty));
            IWebElement lowestPriceProduct = products[0];

            //Search for lowest price product
            foreach (IWebElement product in products)
            {
                _ctrlFunc.ScrollInToView(product, 10, CartPage.ProductPriceColumn);
                _driverUtil.WaitFor(2000, CartPage.ProductPriceColumn, CartPage.PageName);
                try
                {
                    float currentProductPrice = float.Parse(product.FindElement(CartPage.ProductPrice).Text.ReplaceFirst("$", string.Empty));

                    if (currentProductPrice < lowest)
                    {
                        lowest = currentProductPrice;
                        lowestPriceProduct = product;
                    }
                }
                //Ignore the last total row in the table
                catch (NoSuchElementException ex)
                {
                    Console.WriteLine("Ignoring last row in the list of products table as it doesn't have price column" + ex.Message);
                }
            }
            return lowestPriceProduct;
        }

    }
}

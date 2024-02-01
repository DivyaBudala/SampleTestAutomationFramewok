Feature: CartTest

@Browser_Chrome
Scenario: Validate Cart functionality
	Given User open the url "https://cms.demo.katalon.com/"
	When I add four random items to my cart
	And I view my Cart
	Then I find total four items listed in my cart
	When I search for lowest price item
	And I am able to remove the lowest price item from my cart
	Then I am able to verify three items in my cart

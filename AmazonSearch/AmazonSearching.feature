Feature: AmazonSearching
	In order to buy a product online 
	As a potencial buyer
	I want to search products and compare prices

@mytag
Scenario: Search for a product 
   Given I go to amazon
   And I login with my "email" and "password" 
   Then I Search for product: "Samsung Galaxy S9 64GB"
   Then I Select first product and validate first price vs detail price
   When I click on Add to Cart
   And Validate first price vs current price And validate Shop car has 1 item
   Then I Search for second product: "Alienware Aw3418DW" 
   And Select first product
   Then I add second product to the cart And verify cart has two items

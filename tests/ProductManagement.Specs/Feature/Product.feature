Feature: Product
	In order to create a product
	As a math idiot
	I want to be told the sum of two numbers

Background:Create a Product
	Given I have a product called 'Viviana Farmhouse Metal Platform Bed'
	And  'Viviana Farmhouse Metal Platform Bed' as a product has the following properties
		| EnglishTitle                     | IsActive | BrandId | AtAGlance               | Description                                                                             |
		| Viviana Farmhouse Metal Platform | true     | 1       | Box Spring Not Required | With the farmhouse metal bed, you get a little bit of everything in one trendy package. |
	When I register the 'Viviana Farmhouse Metal Platform Bed' as a product
	Then It should be appear in the list of products


Scenario: Add a product variety
	Given I have a product called 'Viviana Farmhouse Metal Platform Bed'
	And  A product variety should add to 'Viviana Farmhouse Metal Platform Bed'  which has the following properties
		| ColorType | ColorImageName | ProductImageType | ProductAmount | ProductDiscountPercent |
		| 1         | red.jpg        | 1                | 3500000       | 10                     |
	And Each product variety has the some images
		| Images |
		| 1.png  |
		| 2.png  |
		| 3.png  |
		| 1.png  |
	When I submit the product variety
	Then It should be appear in the list of 'Viviana Farmhouse Metal Platform Bed'

Scenario: Update product dimension
	Given I have a product called 'Viviana Farmhouse Metal Platform Bed'
	When I submit to update product dimension
	Then 'Viviana Farmhouse Metal Platform Bed' dimension should be updated

Scenario: Update product specification
	Given I have a product called 'Viviana Farmhouse Metal Platform Bed'
	When I submit to update product specification
	Then 'Viviana Farmhouse Metal Platform Bed' specification should be updated
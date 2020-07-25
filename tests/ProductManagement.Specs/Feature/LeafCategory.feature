Feature: LeafCategory
	In order to create a leaf categoty to display in clients
	As a admin user
	I want to define a leaf categoty

Scenario: Leaf Category
	Given I have a leaf category called 'Beds'
	And   'Beds' as leaf category has the following properties
		| SubCategoryId | MainCategoryId | IsActive | ImageName |
		| 1             | 1              | true     | image.png |
	When I register the 'Beds'
	Then It should be appear in the list of leaf categories
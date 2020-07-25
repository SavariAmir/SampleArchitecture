Feature: MainCategory
	In order to create a main categoty to display in clients
	As a admin user
	I want to define a main categoty and their categories

Scenario: Main Category
	Given I have a main category called 'Furniture'
	And  'Furniture' as main category has the following properties
		| ImageName     | IsActive |
		| furniture.jpg | true     |
	When I register the 'Furniture' as a main category
	Then It should be appear in the list of main category

	Scenario: Category
	Given I have a main category called 'Furniture'
	And  'Furniture' as main category has the following properties
		| ImageName     | IsActive |
		| furniture.jpg | true     |
	When I register the 'Furniture' as a main category
	And I have a category called 'TV Stand' with parent 'Furniture'
	And 'TV Stand' as category has the following properties
		| ImageName   | IsActive |
		| TVStand.jpg | true     |
	When I register the 'TV Stand' as a category
	Then It should be appear in the list of categories
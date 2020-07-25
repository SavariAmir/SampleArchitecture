Feature: Dimension
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Background:
	Given I have a leaf category called 'Beds'
	And   'Beds' as leaf category has the following properties
		| SubCategoryId | MainCategoryId | IsActive | ImageName |
		| 1             | 1              | true     | image.png |
	When I register the 'Beds'

Scenario: Dimension
	Given I have a leaf category called 'Beds'
	And Dimension should add to 'Beds'
	And 'Beds' has the following groups
		| groups     |
		| Twin Size  |
		| Full Size  |
		| Queen Size |
		| King Size  |
	And 'Twin Size' has the following items
		| Title                  | UnitOfMeasurementType |
		| Overall Product Weight | KG                    |
		| Overall Product Height | Centimeter            |
	And 'Full Size' has the following items
		| Title                  | UnitOfMeasurementType |
		| Overall Product Weight | KG                    |
		| Overall Product Height | Centimeter            |
	And 'Queen Size' has the following items
		| Title                  | UnitOfMeasurementType |
		| Overall Product Weight | KG                    |
		| Overall Product Height | Centimeter            |
	And 'King Size' has the following items
		| Title                  | UnitOfMeasurementType |
		| Overall Product Weight | KG                    |
		| Overall Product Height | Centimeter            |
	When I submit the dimension
	Then 'Beds' now should have the dimension
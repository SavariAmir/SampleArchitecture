Feature: Specification
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Background:
	Given I have a leaf category called 'Beds'
	And   'Beds' as leaf category has the following properties
		| SubCategoryId | MainCategoryId | IsActive | ImageName |
		| 1             | 1              | true     | image.png |
	When I register the 'Beds'

Scenario: Specification
	Given I have a leaf category called 'Beds'
	And A Specification should add to 'Beds'
	And 'Beds' has the following specification groups
		| groups   |
		| Features |
		| Assembly |
	And 'Features' group specification has the following items
		| Title                        | SpecificationItemValueType |
		| Frame Material               | Select                     |
		| Weight Capacity (Queen Size) | Number                     |
		| Mattress Included            | Boolean                    |
	And 'Assembly' group specification has the following items
		| Title                   | SpecificationItemValueType |
		| Level of Assembly       | Text                       |
		| Adult Assembly Required | Boolean                    |
	When I submit the specification
	Then 'Beds' now should have the specification
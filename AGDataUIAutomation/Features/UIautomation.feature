Feature: AGdata UI Automation Assessment
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](AGDataUIAutomation/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: Store all the values in the List
	Given user visits the url "https://www.agdata.com"
	And user clicks on Company button
	And user select the Overview option
	Then user stores all the values in list

Scenario: Validate Conatct Page URL
	Given user visits the url "https://www.agdata.com"
	And user clicks on Company button
	And user select the Overview option
	And user click let get started
	Then validate contact page

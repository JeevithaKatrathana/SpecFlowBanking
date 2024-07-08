Feature: Banking
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](SpecFlowBanking/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: Login to Banking Application
	Given Launch Banking Application
	When User Enters Valid UserName ,Password and clicks Login button
	| testdataName | UserName | Password |  
	| data1        | admin   | admin   |
	
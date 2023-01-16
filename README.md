<h1># Sprout.Exam.WebApp by Francis Mario Calvadores</h1> <br>
<b>Notes:</b><br>

- Please use branch/web-test for testing the app
- The app is now capable of creating a new database
- I've added field inside Employee table:
  *  Salary - this can be added/editted on Employee CRUD module
- However, If you wish to retain an existing database named "SproutExamDb", <br> please add run this SQL Script to SQL Server Management Studio (SSMS):
<pre>
  USE [SproutExamDb]
  ALTER TABLE Employee ADD [Salary] real;
</pre>
<hr>

<b>Question:</b><br>
If we are going to deploy this on production, what do you think is the next improvement that you will prioritize next? This can be a feature, a tech debt, or an architectural design.

<b>Answer:</b><br>
Next Feature(s) would be: <br>
- Employee and Payroll and all other payroll modules should be less coupled and should separated in terms of services, controllers and views.
- Additional module for Date Time Record. 
- handling semi-monthly type or payroll (Salary Frequency module: for monthly, weekly and semi-monthly)
- The app could handle multiple companies. <br>
	* Example: if the client is a group of company per se, the app should be able to process another instance of company.
- Government Mandated Contributions Tables:  {example: sss, philhealth, pag-ibig}
- Generation Payroll Reports such as: employee list, payslip, total absence, 13th month pay and etc.
- Data Privacy - the amount salary or the be hidden that only payroll admin or hr could view this.

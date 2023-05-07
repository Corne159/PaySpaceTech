Using MySQL Workbench connect to a local instance of your MySQL

--- Step 1 ---
Create a new SQL tab for executing queries and then drag the "PaySpaceTechDb_MySQL.sql" file into it and click on the execute button to restore the database

--- Step 2 ---
Create a user under Administration > Users and Privileges
	- Click on "Add Account"
	- Login Name: payspace
	- Authentication Type: Standard
	- Limit to Hosts Matching: localhost
	- Password: P@yspace123

--- Step 3 ---
Under the "Schema Privileges" tab add a new entry and select all. Then click apply.
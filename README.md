# CoreDemoADO.NET

CoreDemoADO.NET is a an ASP.NET Core Application that does CRUD (Create, Read, Update and Delete) operations on a SQL Server Database using ADO.NET.


## Pre-Requisite
The following are mandatory for the CoreDemoADO.NET application to run :

1. Microsoft .NET Core 5.0 Runtime or SDK.
2. Microsoft SQL Server. 


## Installation

1. Run Visual Studio 2019

2. Select 'Clone a repository'

 	Repository location: 
 	https://github.com/timanand/CoreDemoADO.NET.git

 	Path:
 	This is the location on your computer where Repository shall be copied to. For example: 'C:\DEVELOP\CoreDemoADO.NET\'.

 	Click on 'Clone' button.




3. On the right side, you will see the Solution Explorer window. Double click on 'CoreDemoADO.NET.sln'.



4. From 'Build' menu, select 'Rebuild Solution'. 
	--> It will say : 
		
		- Rebuild All: 3 succeeded


5. Goto Solution Explorer

	Right mouse click on 'CoreDemoADO.NET.Application'
	Select 'Manage User Secrets'
	Paste the following :

	  "ConnectionStrings": {
    		"StaffConnex": "Data Source=; Initial Catalog=CoreDemoADONet; 
				integrated security=false;user id=;password=;"
  			       }

			Update the following based on your SQL Server Management Studio settings:
			
			Data Source=
			User Id=
			Password=


6. From 'Build' menu, select 'Rebuild Solution'.
	--> It will say : 
		
		- Rebuild All: 3 succeeded



7. Run SQL Script into CoreDemoADONet SQL Server Database by following the instructions:

	i. Run SQL Server Management Studio or Equivalent

	ii. Sign onto System

	iii. In Explorer, double click on file, '\CoreDemoADO.NET\CoreDemoADO.NET.Application\SQL Server Files\CreateDatabaseAndTable.sql'
	

	iv. Run the Execute command or equivalent to run the query which will create Database, 'CoreDemoADONet' and Table : 'dbo.StaffMembers' in SQL Server.



## Usage

Press F5 or click on the Play button icon from the toolbar in Visual Studio 2019 for the above solution.

When you run the Web application it will allow the ability to Create, Update and Delete Staff Members.




## License & Copyright

(c) 2021 Arvinder Anand (Tim)

 

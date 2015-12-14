# Dapper.Accelr8
A Dapper Based Data Access Framework with Templating, I've included templates with some peices from 
SubSonic, and Peta Poco;

also https://www.nuget.org/packages/T4

and Damien G's output template https://damieng.com/blog/2009/11/06/multiple-outputs-from-t4-made-easy-revisited


# How to install
For single project data access layer run this command in your data access project:
Install-Package Dapper.Accelr8.Sql 

It will automatically include these projects:
  Dapper
  Dapper.Accelr8.Repo 
  Dapper.Accelr8.Domain
  
For distributed projects run these commands:
Run Install-Package Dapper.Accelr8.Sql in your Sql layer.
Remove the binary references to:
Dapper.Accelr8.Repo 
Dapper.Accelr8.Domain

Run Install-Package Dapper.Accelr8.Repo.Src in your repo project.

Remove binary references to 
Dapper.Accelr8.Domain

Run Install-Package Dapper.Accelr8.Domain.Src in your domain project.

Make sure to include your domain project in your repository project, and both in your Sql project.

# How to use
To prevent some odd behavior, close all other instances of Visual Studio.
Open the schema.ttinclude

edit these variable to set the location of your output files for the templates.

keep CacheLocatorResults set to false.
		
	-this adds dirty property tracking to your domain templates
UseDirtyProperties = true;

	- these are the properties for your domain prjoect.
	- this variable allows you to use your own base entity class as long as it can fulfill the same Dapper.Accelr8.Domain IEntity
public static string BaseDomainEntity = "Dapper.Accelr8.Repo.Domain.BaseEntity";
public static string DomainProject = "Dapper.Accelr8.Sql";
public static string DomainNamespace = @"Dapper.Accelr8.Domain";
public static string DomainDirectory = @"Domain";

    - these properties below are for generating the sql and belong somewhere in your sql project.
public static string WritersProject = "Dapper.Accelr8.Sql";
public static string WritersNamespace = @"Dapper.Accelr8.Writers";
public static string WritersDirectory = @"Writers";

public static string ReadersProject = "Dapper.Accelr8.Sql";
public static string ReadersNamespace = @"Dapper.Accelr8.Readers";
public static string ReadersDirectory = @"Readers";

public static string TableInfoProject = "Dapper.Accelr8.Sql";
public static string TableInfoNamespace = @"Dapper.Accelr8.TableInfos";
public static string TableInfoDirectory = @"TableInfos";
		
	  - set your connection string and database here
static string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=AdventureWorks;Integrated Security=SSPI;";
static string _database = @"AdventureWorks";
		


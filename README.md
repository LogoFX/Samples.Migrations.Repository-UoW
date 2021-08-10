# The Sample: How to migrate from ADO.NET to Entity Framework using the Repository and Unit of Work design patterns

The step by step sample shows how to create a minimalistic ASP.NET Web API 2 Web API server application using following best practices:
* The Modularity — To build the solution with REALLY independent modules (aka, assemblies, projects)
* The Automation — To automate development tasks, like as a builds, code generation, etc.
* The Standards — To use all the power of OpenAPI standards, automatic code generation for service facades and clients (Single Source of Truth)
* The Migration - To build the data access layer such as it could allow migration from ADO.NET to EF (it's necessary for future migration from .NET Framework to .NET 5.0) as easy as possible.
* The bonus — The GraphQL endpoint project built on top of .NET. 5.0 framework, but using same infrastructures developed with .NET Framework 4.7.2.

## The Source Code

The source code contains four subfolders named as ``part(n)``. Each of the parts are just steps on the solution genesis roadmap.

### Part 1
* The API project uses different modules to access to database due selected solution build configuration.
* The GraphQL project uses direct link to AdoDotNet module project and works only ```AdoDotNet``` solution build configuration.
* Entities, models and data service are configured to work only with one kind of data objects: ```Court```.

### Part 2
* Both API and GraphQL projects use different modules to access to database due selected solution build configuration.
* Entities, models and data service are configured to work only with one kind of data objects: ```Court```.

### Part 3
* Both API and GraphQL projects use different modules to access to database due selected solution build configuration.
* Entities, models and data service are configured to work with two kind of data objects: ```Court```, ```CourtLevel```.

### Part 4
* ```Court``` entity has nested property ```Level``` which linked to ```CourtLevels``` table via ```LevelId``` foreign key.

## Prerequisites

1. Microsoft .NET Framework v.4.7.2 or above;
2. .NET Framework v.5.0 or above;
3. NodeJs ≥v.14;
4. Visual Studio 2019.

## How to start
1. Download, or clone, or fork the repository.
1. Choose a step (```src/Part(n)```) folder to start to play with solution. We recommend to start from ```part3``` or ```part4```, and examine all the way from Part1 to Part(n) after.
1. Run ```/devops/run-once.cmd```. It installs globally nswag package.
1. Open the solution found in one of Part(n) folders in the Visual Studio 2019.
1. Create database using ```Samples.Server.SampleDB``` project.
   1. Build the database project.
   1. Launch 'publish' command.   
   ![Publish Settings](/public/img/image01.png)   
   1. Choose connection.   
   ![Connection Settings](/public/img/image02.png)  
   3. In field "Database Name" type new database name (i. e. SampleDatabase2).
   4. Press "OK".
   5. Press "Publish".
   
1. In solution properties dialog set multiply startup projects: ```Samples.Server.Facade``` and ```Samples.Server.GraphQL.Facade```.
1. Set connections string.
   1. In root of the ```Samples.Server.Facade``` project edit ```WebConnectionString.config``` file. Set connection string named ```appEntities```.
   1. In root of the ```Samples.Server.GraphQL.Facade``` project edit ```appsettings.json``` file. Set connection string named ```appEntities```
1. Start projects configuration
   1. In the ```Samples.Server.Facade``` project find and open for edit ```WebConnectionString.config``` file. Define the connection string named ```appEntities```. Open the project properties. Navigate to "Web Settings" and set "Specific Page" to open "swagger" page.   
   ![Web Settings](/public/img/image03.png)
   1. In the ```Samples.Server.GraphQL.Facade``` project find and open for edit ```appsettings.json``` file. Define the connection string named ```appEntities```.
1. Choose ```DebugAdoNet``` or ```DebugEF``` from solution build configuration.
1. Do "Rebuild All".
1. Do "start".

## Solution structure

The solution consists from infrastructures and applicative code. All of the infrastructure projects may be facilitated with additional things and published as packages (recommended). 

The solution contains two entry-point projects:
* Samples.Server.Facade -- API server with swagger;
* Samples.Server.GraphQL.Facade -- GraphQL server;

## Build Configurations

In order to use modularity over configuration approach the solution uses VS Build Configurations tool to build relevant modules only. We prepared two configurations as following:
* ```DebugAdoNet``` — The ```Samples.Server.Data.Context.AdoDotNet``` module (project) will be compiled and used to provide access to database.
* ```DebugEF``` — The ```Samples.Server.Data.Context.EntityFramework``` module (project) will be compiled and used to provide access to database.



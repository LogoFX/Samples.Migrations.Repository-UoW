# The Sample: How to migrate from ADO.NET to Entity Framework using the Repository and Unit of Work design patterns

The step by step sample shows how to create a minimalistic ASP.NET Web API 2 Web API server application using following best practices:
* The Modularity — To build the solution with REALLY independent modules (aka, assemblies, projects)
* The Automation — To automate development tasks, like as a builds, code generation, etc.
* The Standards — To use all the power of OpenAPI standards, automatic code generation for service facades and clients (Single Source of Truth)
* The Migration - To build the data access layer such as it could allow migration from ADO.NET to EF (it's necessary for future migration from .NET Framework to .NET 5.0) as easy as possible.
* The bonus — The GraphQL endpoint project built on top of .NET. 5.0 framework, but using same infrastructures developed with .NET Framework 4.7.2.

## Prerequisites

1. Microsoft .NET Framework v.4.7.2 or above;
2. .NET Framework v.5.0 or above;
3. NodeJs ≥v.14;
4. Visual Studio 2019.

## How to start

1. Run ```/devops/run-once.cmd```. It installs globally nswag package.
2. Open the solution in the Visual Studio 2019.
3. Create database using ```Samples.Server.SampleDB``` project.
   3.1. Build the database project.
   3.2. Launch 'publish' command.
   ![Publish Settings](/public/img/image01.png)   
   1. Choose connection. ![Connection Settings](/public/img/image02.png)  
   1. In field "Database Name" type new database name (i. e. SampleDatabase2).
   1. Press "OK".
   1. Press "Publish".
   
1. In solution properties dialog set multiply startup projects: ```Samples.Server.Facade``` and ```Samples.Server.GraphQL.Facade```.
1. Set connections string.
   1. In root of the ```Samples.Server.Facade``` project edit ```WebConnectionString.config``` file. Set connection string named ```appEntities```.
   1. In root of the ```Samples.Server.GraphQL.Facade``` project edit ```appsettings.json``` file. Set connection string named ```appEntities```
1. Do "rebuild all".
1. Do "start".

## Data

The application uses external data source. For initialize database, the solution contains database project ```Samples.Server.SampleDB``` with proper database structure and sample data. You may publish this project to create a new database.

## Solution structure

The solution consists of two parts. One part is infrastructure, which contains common projects for each step parts.

The solution contains two entry-point projects:
* Samples.Server.Facade -- API server with swagger;
* Samples.Server.GraphQL.Facade -- GraphQL server;

There are two debug build configurations: ```DebugAdoNet``` and ```DebugEF```. In ```DebugAdoNet``` configuration the ```Samples.Server.Data.Context.AdoDotNet``` module project used to database access. In ```DebugEF``` configuration the ```Samples.Server.Data.Context.EntityFramework``` module project used to database access. 

## Start projects configuration

### Samples.Server.Facade

In root of the project edit ```WebConnectionString.config``` file. Set connection string named ```appEntities```. In project properties open Web settings and set "Specific Page" to open "swagger" page.

![Web Settings](/public/img/image03.png)

### Samples.Server.GraphQL.Facade

In root of the project edit ```appsettings.json``` file. Set connection string named ```appEntities```.

# Step parts

There 3 step parts.

## Part 1

* The API project uses different modules to access to database due selected solution build configuration.
* The GraphQL project uses direct link to AdoDotNet module project and works only ```AdoDotNet``` solution build configuration.
* Entities, models and data service are configured to work only with one kind of data objects: ```Court```.

## Part 2

* Both API and GraphQL projects use different modules to access to database due selected solution build configuration.
* Entities, models and data service are configured to work only with one kind of data objects: ```Court```.

## Part 3

* Both API and GraphQL projects use different modules to access to database due selected solution build configuration.
* Entities, models and data service are configured to work with two kind of data objects: ```Court```, ```CourtLevel```.

## Part 4

* ```Court``` entity has nested property ```Level``` which linked to ```CourtLevels``` table via ```LevelId``` foreign key.

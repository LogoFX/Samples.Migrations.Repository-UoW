# elastic-search-api
Sample of ASP.NET Web API 2 Web API server application (in 3 parts) to demonstrate usage of automatic server code generation based on YAML schema. There are several methods to access to database.

## Prerequisites

The application was made for .NET 4.7.2 / .NET 5.0 and Visual Studio 2019.

Also it uses Node.js and NPM. Before launch the application you may run ```/devops/run-once.cmd``` to install necessary packages.

## How to start

1. Install Node.js (ver. >= 14) and npm package manager.
1. Run ```/devops/run-once.cmd```. It installs globally nswag package.
1. Open the solution in the Visual Studio 2019.
1. Create database using ```Ngcs.ElasticSearch.SampleDB``` project.
   1. Build the database project.
   1. Launch 'publish' command.
   ![alt text](/public/img/image01.png)
   1. Choose connection.
   ![alt text](/public/img/image02.png)
   1. In field "Database Name" type new database name (i. e. SampleDatabase2).
   1. Press "OK".
   1. Press "Publish".
   
1. In solution properties dialog set multiply startup projects: ```Ngcs.Server.Facade``` and ```Ngcs.Server.GraphQL.Facade```.
1. Set connections string.
   1. In root of the ```Ngcs.Server.Facade``` project edit ```WebConnectionString.config``` file. Set connection string named ```appEntities```.
   1. In root of the ```Ngcs.Server.GraphQL.Facade``` project edit ```appsettings.json``` file. Set connection string named ```appEntities```
1. Do "rebuild all".
1. Do "start".

## Data

The application uses external data source. For initialize database, the solution contains database project ```Ngcs.ElasticSearch.SampleDB``` with proper database structure and sample data. You may publish this project to create a new database.

## Solution structure

The solution consists of two parts. One part is infrastructure, which contains common projects for each step parts.

The solution contains two entry-point projects:
* Ngcs.Server.Facade -- API server with swagger;
* Ngcs.Server.GraphQL.Facade -- GraphQL server;

There are two debug build configurations: ```DebugAdoNet``` and ```DebugEF```. In ```DebugAdoNet``` configuration the ```Ngcs.ElasticSearch.Data.Context.AdoDotNet``` module project used to database access. In ```DebugEF``` configuration the ```Ngcs.ElasticSearch.Data.Context.EntityFramework``` module project used to database access. 

## Start projects configuration

### Ngcs.Server.Facade

In root of the project edit ```WebConnectionString.config``` file. Set connection string named ```appEntities```.

### Ngcs.Server.GraphQL.Facade

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

# Rest API for To-do List Items

## Description

This project is a REST API designed to Create, Retrieve, Update, and Delete to-do list items. It utilizes MongoDB as the repository. The primary goal is to showcase skills in creating a REST API with CRUD functionalities while adhering to best practices such as testing, naming conventions, code structure, and readability.

## Approach
I've separated my projects into three areas: API, Core, and Infrastructure. I've implemented dependency injection to manage instances of repositories and services. The aim was to structure the project in line with the ports and adapters style architecture and keeping the code clean and modular. This approach enables each component to be decoupled, making it easier to test and scale among other reasons.  Furthermore, it provides a clear separation between the API layer and business rules, allowing each layer to be replaced independently if necessary.

There are still areas within the application that require further adaptation. For instance, each method could  have its own class for controller, the service and repository methods could be in each of their classes.  
The following URL’s are some of the sites I have used for reference and research.

https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html

https://ardalis.com/clean-architecture-asp-net-core/

## Technologies

- ASP.NET Core 8
- C#

## Features

- Create new to-do list items
- Retrieve existing to-do list items
- Retrieve existing to-do list based on Id
- Update existing to-do list items
- Delete existing to-do list items

## Installation

**Prerequisites**:

Ensure you have MongoDb Installed on your local computer or use Atlas (cloud version)

1. Navigate to the project directory.
   
2. Install dependencies using `dotnet restore`.
   
3. Set up MongoDB and configure connection string in `appsettings.json`.
  
   Format below:
CustomerDatabase": {
    "ConnectionString": "URL To Database",
    "DatabaseName": "Name of Database",
    "CollectionName": "Name of collection"
  },

4. Run the application using `dotnet run`.

## Endpoints

Below are the endpoints structure detailed:

•	GET: /api/todoitem/   - Returns all the ToDo items

•	GET: /api/todoitem/{id} – Return a ToDoItem based on passed ID

•	POST: /api/todoitem/ - Creates a new ToDo item – using ToDOItem listed object below 

•	PUT:  /api/todoitem/{id}    - Updates the ToDo item of passed in ID using ToDOItem listed object

•	DELETE:  /api/todoitem/{id}    - Deletes a ToDo item based on passed ID  



**Example json for ToDoItem:**


{ 

   "id": "663dcd5a660980dddd4d16cf068",
   
   "description": "Task 1",
   
   "isCompleted": true
   
} 











# Blog-Project
a simple blogging system using ASP.NET and SQL Server as DB storage.

#step 1 : create asp.net web api project 
#step 2 : create ERD for database then i create model for (code first) classes for database (user , categories ,post , comment)
#step 3 : i used (migration) to update database and create a new database in migration folder in config file i used seed function to add
rows in database for testing do not remove migration folder just update database with the exist files 
#step 4 : add 4 controllers for get and post functions to get and create posts , users , categories , comments using view model to map the data 
from to database
#step 5 : install Microsoft.Owin packages to create a startup page to implement the code configuration provider and create an instance of 
class AuthProvider. then i create a class to implement OAuthAuthorizationServerProvider and call our  Model.
This model validates the user from a database. 
#step 6 : then i created an angular 7 Angular application for UI then i create a new service for calling the Web API.
#step 7 : defining the API URL for sending a request to the server to get token. and create guard service to implement can activate function
#step 8 : create a login component then i injected it with the service 
#step 9 : i create a couple of component to represent the data from api using view model to map the data from and to api

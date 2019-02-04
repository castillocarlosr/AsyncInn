# AsyncInn

# Async Inn Management System

## Purpose:
This is my first attempt at creating a working database management system in C# using ASP.NET and all its tools.

## Summary
This is to allow a user to update, add, delete records in a virtual hotel management system.

### How to run the program:
```
Use the link below to find a deployed version on an Azure server.
```
[https://asyncinncarloscastillo.azurewebsites.net](https://asyncinncarloscastillo.azurewebsites.net)


If the site is taken down in the future due to server costs, you may clone down the repo and run the program on your local machine using Visual Studio 2017.

You may look at the source code to ensure nothing evil is in there.
* The web browser will welcome you to a Front Page of Async Inn Hotel Management System.
* The user can then select which table they would like to go to in the database.
* The user can add, update, delete any record within the provided fields.
* The user can click back to the home page at any time.
* When finished viewing, simply exit the web brower.

## Database Schema
## Tables:
* Hotel: Properties Name, Address, & Phone Number.  One to many relationship to HotelRoom table.
* HotelRoom: This is an entity join table.  Composite Key with Hotel ID & RoomNumber.  Properties Price Rate & Pet Friendly.  Many to one relationship to Room table.
* Room: Properties of Room Name & Layout.  Layout type is enum with Studio, 1, 2 bedroom dropdown option.
* RoomAmenities: Pure Join Table with a composite key of primary keys from Room table & Amenities Table. Many to one relationship to both Room table & Amenities table.
* Amenities: Property of specific amenities.  One to many relationship with RoomAmenities table.

## Update 01/29/2019
* Changed Room Controller to have Dependency Injection.
* Changed Hotel Controller to have Dependency Injection.
* Changed Amenities Controller to have Dependency Injection.
## Update 02/03/2019
* Added filter options to Hote, Amenities, and Rooms.
* Removed Edit options for RoomAmenities.
* Display # of rooms per Hotel and # of amenities per Room.
* Write xUnit tests for each all get; set; properties on all Models.
* Write xUnit test for all 
* Deployed to Azure.


Below are screen shots of what this should look like.
###Screen Shot 
![](Assets/SchemaHotel.png?raw=true)
![](Assets/Azure1.PNG?raw=true)
![](Assets/Azure2.PNG?raw=true)
![](Assets/Azure3.PNG?raw=true)
![](Assets/Azure4.PNG?raw=true)
![](Assets/Azure5.PNG?raw=true)

Lab started on January 22, 2019 by Carlos R. Castillo
Thanks for stopping by and stay classy Seattle.

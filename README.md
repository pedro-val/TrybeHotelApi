### TrybeHotel API
This is the repository for the TrybeHotel API, an API developed in several stages for managing cities, hotels, rooms, bookings, and integration with geographical information based on addresses. The API was developed in C# with ASP.NET and uses a database to store information about hotels, cities, rooms, users, and bookings.

### Project Stages
The TrybeHotel project was developed in four distinct stages, each with its own requirements and functionalities. Below, you will find a description of each project stage and the technologies used:

### Phase A: Starting the Development
In this phase, the goal was to start developing the API and create routes for the entities of cities, hotels, and rooms. Endpoints were developed to list, create, and update information about these entities.

### Technologies Used:

ASP.NET
C#
Database

### Phase B: Adding Authentication and Security
In this phase, the API was expanded to include user authentication and authorization policies. Routes for user registration and login were added, as well as authorization policies for secure operations.

### Technologies Used:

ASP.NET
C#
JWT Tokens
Authorization Policies

### Phase C: Integration with Geographical Information
In this phase, the API was enhanced to search for hotels based on geographical address information. Attributes and functionalities were added to improve hotel searches near an address.

### Technologies Used:

ASP.NET
C#
Integration with External Geographical Information API

### Phase D: Preparing for Deployment
In the final phase, the API was prepared for deployment. A standard route to check the application’s status was added, and a Dockerfile was created to facilitate the deployment of the API in a production environment.

### Technologies Used:

ASP.NET
C#
Docker

### API Endpoints
The TrybeHotel API has several endpoints to access different functionalities. Below, we list the main endpoints and their descriptions:

### Cities
GET /city: Lists all registered cities.
POST /city: Creates a new city.
### Hotels
GET /hotel: Lists all registered hotels.
POST /hotel: Creates a new hotel.
### Rooms
GET /room/:hotelId: Lists all rooms in a specific hotel.
POST /room: Creates a new room.
DELETE /room/:roomId: Deletes a specific room.
### Users
POST /user: Creates a new user.
POST /login: Logs in a user.
GET /user: Lists all registered users.
### Bookings
POST /booking: Creates a new booking.
GET /booking: Lists all made bookings.
### Geographical Information
GET /geo/status: Checks the status of geographical information.
GET /geo/address: Searches for nearby hotels based on an address.

### How to Use the API
To use the TrybeHotel API, follow these steps:

Clone this repository.
Open the project in your favorite development IDE.
Ensure you have all the necessary technologies installed.
Run the API locally or deploy it to a production environment if needed.
Use the API endpoints as needed by making HTTP requests to them.
Remember to provide authentication data when necessary and follow authorization policies to access secure routes.

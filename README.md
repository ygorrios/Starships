# Starships

The application will take as input a distance in mega lights (MGLT).
The output should be a collection of all the star ships and the total amount of stops required to make the distance between the planets.
 
The solution should not assume the data is static.
All other application details are at your own discretion.

{
  Sample output for 1000000:
  Y-wing: 74
  Millennium Falcon: 9
  Rebel Transport: 11
}
 
Requirements
1) The completed code should be submitted along with
2) Accompanying documentation
3) Tests and instructions on the usage of the application.

# Documentation

This application it’s for a starship resource is a single transport craft that has hyperdrive capability.

When the real problem is: want to know for all SW star ships, to cover a given distance, how many stops for resupply are required.

The system was built with good architecture, with great design, with a system organized, all classes separated like Views with front-end to do a communication to controller, in this layer happen any validations and after send a request to Model to do post with API and returns the requisition to controller to calculate the problem and show the result in other View.

Utilizing C# ASP.NET MVC with Framework 4.5.2. The application does a Post async with HTTPCLIENT API and send a request to SW API. And I built a short version in JavaScript and HTML to show you I have capacity to adapt to new situations and the application does a Post with Ajax.

Everyone can use the program, because it’s a simple software. The application will take as input a distance in mega lights (MGLT).
The output should be a collection of all the star ships and the total amount of stops required to make the distance between the planets.


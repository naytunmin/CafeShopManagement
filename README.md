# CafeShopManagement
 
This project is built using .NET Core 8 with Clean Architecture and MediatR. 
It demonstrates how to set up a simple Cafe Shop Management system, utilizing a layered architecture to separate concerns and ensure maintainability and scalability.

Required Software Microsoft Visual Studio Community 2022 Download and install Visual Studio Community 2022 with the required .NET Core 8 SDK and components. Ensure that you include the workload for .NET development.

Microsoft SQL Server (19.3) Download and install Microsoft SQL Server (version 19.3 or higher) and Microsoft SQL Server Management Studio (SSMS) to manage your databases.

SQL Server Database Setup Create a new database named CafeShopManagement in your SQL Server instance.

Database Initialization To initialize the database schema and populate it with initial data, run the provided CafeShopManagement.sql script. This script will create the necessary tables and populate them with initial data.

Open SQL Server Management Studio (SSMS) and connect to your SQL Server instance. Open the CafeShopManagement.sql file.Execute the script in SSMS to create the tables and populate them.

How to Run the Project Clone the Repository Clone this repository to your local machine using your preferred method (e.g., GitHub Desktop, command line, or Visual Studio).

bash Copy code git clone https://github.com/naytunmin/CafeShopManagement_BE.git t Open the Project in Visual Studio Open the solution file (CafeShopManagement.sln) in Microsoft Visual Studio Community 2022.

Configure the Database Connection Ensure that the appsettings.json file in the project contains the correct connection string for your CafeShopManagement database.

Example: "ConnectionStrings": { "DefaultConnection": "Server=your_server_name;Database=CafeShopManagement;User Id=your_user_id;Password=your_password;" }

Build and Run the Project In Visual Studio, select Build > Build Solution to build the application. 
Then, select CafeShopMgmt.Presentation.API project to Set as Startup Project and Run (or press F5) to start the application.cafeShopMgmt

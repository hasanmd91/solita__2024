# Project: Helsinki-city-bike-app

Made By: Hasan

## Purpose of this project

This is my solution for the pre-assignment for Solita Dev Academy Finland 2024

You can find the original assignment here --> https://github.com/solita/dev-academy-spring-2024-exercise

## Introduction

This is a web application that displays data from journeys made with city bikes in the Helsinki Capital area. The application allows users to view information about bike stations and journeys, including details such as departure and return stations, distance, and duration.

Users can view a list of all of the journeys made in 2021 summer, as well as detailed information about individual bike stations,including the total number of journeys starting from or ending at the station, the average distance of those journeys, and the top 5 most popular return and departure stations.

# Backend

This backend project is build wtih ASP.NET Core, Entity Framework Core, and PostgreSQL and is deployed on Microsoft Azure. The backend provides endpoints for performing CRUD operations Backend deployed link: https://solita2024.azurewebsites.net/

## Technologies Utilized

- Backend Development: C# and Asp.NET 8
- Data Access: Entity Framework Core
- Database Management: PostgreSQL
- Deployment: Microsoft Azure

## Swagger Documentation

The API endpoints are documented using Swagger. You can explore the API documentation [here](https://solita2024.azurewebsites.net/).

## Architecture Overview

### Clean Architecture

This application follows Clean architectural approach that promotes separation of concerns and independence of frameworks. It divides an application into layers with specific responsibilities, allowing for easier maintenance, testing, and scalability.

Layers:

#### Core Layer

- Responsible for containing the application's business logic and entities.
- Defines the foundational elements of the application, independent of any external concerns.
- Contains domain models, interfaces, and business rules.

#### Service Layer

- Houses the application's use cases or application-specific business logic.
- Implements business logic by orchestrating interactions between the Core layer and external dependencies.
- Provides services to the Controller layer for handling requests from clients.

#### Controller Layer

- Acts as the entry point for incoming requests from clients.
- Handles HTTP requests and responses.
- Communicates with the Service layer to execute business logic and return results to clients.

#### Web API Layer

- Exposes the application's functionality as a RESTful API.
- Utilizes ASP.NET Web API to handle HTTP requests and responses.
- Interacts with the Controller layer to process requests and return appropriate responses.

#### Architecture Diagram:

![Architecture](/Images/architecture.png)

## Database Schema Overview

### Data

- Data imported from HSL .csv files to Azure Postgress sql database.
- Removed journeys that lasted less than 10 seconds
- Removed journeys that covered distance shorter than 10 meters
- Removed duplicate entries

#### Database Setup Script

```
BEGIN;

CREATE TABLE IF NOT EXISTS
(

    CONSTRAINT pk___ef_migrations_history PRIMARY KEY (migration_id)
);

CREATE TABLE IF NOT EXISTS public.journeys
(

    CONSTRAINT pk_journeys PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS public.stations
(

    CONSTRAINT pk_stations PRIMARY KEY (id)
);

ALTER TABLE IF EXISTS public.journeys
    ADD CONSTRAINT fk_journeys_stations_departure_station_id FOREIGN KEY (departure_station_id)
    REFERENCES public.stations (id) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE CASCADE;
CREATE INDEX IF NOT EXISTS ix_journeys_departure_station_id
    ON public.journeys(departure_station_id);


ALTER TABLE IF EXISTS public.journeys
    ADD CONSTRAINT fk_journeys_stations_return_station_id FOREIGN KEY (return_station_id)
    REFERENCES public.stations (id) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE CASCADE;
CREATE INDEX IF NOT EXISTS ix_journeys_return_station_id
    ON public.journeys(return_station_id);

END;
```

#### Entity-Relationship Diagram:

![erd](/Images/erd.png)

## Deployment

The backend of this project was deployed using Microsoft Azure Web App service.

To deploy the backend:

- Navigate to the Web API layer of your project.
- Run the following command to publish the project:

```
  dotnet publish -c Release -o ./publish

```

- After successful publishing, use the Azure App Service extension to deploy the contents of the generated publish folder Microsoft Azure Web App directly from Visual Studio Code.

## How to run the project

### Project Setup and Database Configuration Instructions

1. **Clone or Copy the Project:**

   - Clone the project from GitHub to your local machine using Git. Alternatively, you can directly import the project into Visual Studio 2022 by following the instructions provided [here](https://learn.microsoft.com/en-us/visualstudio/get-started/tutorial-open-project-from-repo?view=vs-2022).

2. **Package Installation:**

   - Ensure that all required packages in each layer of the project are installed. Navigate to each layer and execute the following command in the terminal or command prompt:
     ```
     dotnet restore
     ```

3. **Configuration of `appsettings.json`:**

   - Create a local `appsettings.json` file in the WebAPI layer directory of the project.
   - Use the provided template below and customize it with your specific database connection information:
     ```json
     {
       "AllowedHosts": "*",
       "ConnectionStrings": {
         "SolitaDB": "YOUR_DATABASE_CONNECTION_STRING_HERE"
       }
     }
     ```

4. **Execution of Entity Framework (EF) Core Migrations:**

   - Update the database schema by executing Entity Framework (EF) Core migrations. Navigate to the project containing the DbContext and run the following commands in the terminal or command prompt:
     ```
     dotnet ef migrations add <Migration_Name>
     dotnet ef database update
     ```

5. **Data Import using pgAdmin:**

   - Utilize pgAdmin to import data from the CSV file into the database.
   - Remove unnecessary lines from the CSV file and validate it according to the station and journey entities.
   - Additionally, you can use pgAdmin to connect your cloud database and import CSV data into your cloud PostgreSQL database.

6. **Important Note:**
   - The size of the database file might be considerable, and the import process could take some time.
   - It's recommended to ensure a stable internet connection during the import process.

## Testing

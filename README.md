# Food Trucks Buhler

A small ASP.NET Core web application for finding San Francisco food trucks that serve a preferred type of food. Results are sorted by distance from the location you enter.

## Features

- Search using latitude and longitude.
- Filter food trucks by food description. The search ignores letter case and matches partial words.
- Choose how many results to show, from 1 to 50.
- See each result's name, food description, address, permit status, and distance.
- Uses a local CSV data file; no database or external API is required at runtime.

## Requirements

- .NET 8 SDK

## Run the application

From the repository directory, run:

```text
dotnet restore
dotnet run
```

Open the local URL printed in the terminal. In Visual Studio, open `FoodTrucks.sln` and run the `FoodTrucks` project.

## Search defaults

The initial search uses San Francisco coordinates (latitude `37.7749`, longitude `-122.4194`) and shows the 10 closest results. Leave the food field empty to search across all food types.

Latitude must be between -90 and 90, longitude between -180 and 180, and the result count between 1 and 50.

## Data

The application reads `Data/Mobile_Food_Facility_Permit.csv` at startup for each search. This is a snapshot of San Francisco mobile food facility permit data. The data may not reflect current locations, menus, or permit status.

## Technology

- ASP.NET Core Razor Pages
- .NET 8
- CsvHelper

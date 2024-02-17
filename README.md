# Factory

Created By: Nikkita Torres

## Description 

The Factory web application is designed to make it easier for the user to create and track employees (engineers), machines in a factory, and which engineers are licensed to work on which machine. It accomplishes this by creating many-to-many relationships, connecting enigneers to machines through the license applied to each engineer.

## Technologies Used

* C#
* MySQL Workbench 8.0 CE
* HTML
* Razor Pages
* ASP.NET Core
* Entity Framework Core
* dotnet-ef

## Setup/Installation Requirements

1. Clone [this](https://github.com/NikkitaTorres/SillystringFactory.git) repository to your desktop.
2. You can either import the nikkita_torres.sql file into MySQL Workbench to re-create the database or use migrations to re-create and update the database. You can import the file by:

- Selecting "Data Import/Export" in the Navigator/Administration"
- Select "Import from Self-Contained File" and select the "nikkita_torres" file inside of the Factory.Solution folder.
- You can rename this file by clicking "New..." next to the "Default Schema to be Imported To", but make sure to adjust the "database=" accordingly on step 4.
- Finally, click the "Start Import" button located in the bottom right.

To create the database using migrations:
- First install dotnet-ef if you haven't already done so. This can be accomplished by running "dotnet tool install --global dotnet-ef --version 6.0.0" in the terminal. If you've already done this, move onto the next step.
- Then, in the production directory (Factory) of the project, run "dotnet add package Microsoft.EntityFrameworkCore.Design -v 6.0.0" in the terminal to 
- Run "dotnet ef migrations add Initial" in the terminal. "Initial" can be renamed to something else here, but it is common to leave it as "Initial" or something with a similair meaning for the first migration.
- Finally, run "dotnet ef database update" in terminal to update/create the database.

After you are finished with the above steps, reopen the "Navigator > Schemas tab". Right click and select "Refresh All". The new database will appear.
3. This project requires a file named "appsettings.json". Create this file at the top level directory of the project (Factory.Solution) by typing "touch appsettings.json" into your terminal.
4. After creating the file, add the following code to the file: "{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database="";uid=YOUR_USERNAME_HERE;pwd=YOUR_PASSWORD_HERE;"
  }
}".
The database="" apostrophes should be changed to whatever you named the sql file that was imported (default: nikkita_torres). Make sure to replace the "YOUR_USERNAME_HERE" and "YOUR_PASSWORD_HERE" with your own username and password for MySQL Workbench, no apostrophes needed.
5. Navigate to the Factory directory and run "dotnet build" in the terminal to compile the code.
6. Use "dotnet restore" in the Factory directory to install necessary packages.
7. Use "dotnet watch run" in the Factory directory to launch the project.

## Know bugs

No known bugs at this time.

## License

MIT License

Copyright (c) [2024] [Nikkita Torres]

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.


//bugsquashing
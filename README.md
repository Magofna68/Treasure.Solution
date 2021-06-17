<br>
<p align="center">
  <big>||  &nbsp;&nbsp;&nbsp;<u><b>Treasure Finder API</b></u>&nbsp;&nbsp;&nbsp;  ||</big>
</p>
<p align="center">Changing the world one line of code at a time.<br></p>
<p align="center">
  <small>June 17th, 2021.</small><br>
    <p align="center">
        <a href="https://github.com/Magofna68/MessageBoard.Solution/stargazers">
            <img src="https://img.shields.io/github/license/Magofna68/PierresTreats.Solution?style=plastic">
        </a>
        ¨
        <a href="https://github.com/Magofna68/MessageBoard.Solution/issues">
            <img src="https://img.shields.io/github/last-commit/Magofna68/MessageBoard.Solution?style=plastic">
        </a>
        ¨
        <a href="https://linkedin.com/in/Magofna68">
            <img src="https://img.shields.io/badge/-LinkedIn-black.svg?style=plastic&logo=linkedin&colorB=2867B2">
        </a>
    </p>
<p align="center">Contributors:<br><small>Brandon Magofna, Nick Reeder, Thomas Russel, & Thomas Friedrichs</small></p>
<p align="center">
    <!-- Project Avatar/Logo -->
    <p align="center">
    </p>
    <p align="center">
      __________________________________________________
    </p>
    <br>
    <p align="center"><a href="https://github.com/Magofna68">
        <img src="https://avatars.githubusercontent.com/u/80496559?v=4">
    </a></p>
    <br>
    <!-- GitHub Link -->
    <!-- Project Shields -->
</p>

------------------------------

# 🌐 About the Project
## This is one of two componenets we created for our wk 14 Team Week project at Epicodus (wk 14). This is the API side; hosting the client data for consumption.
<br>
This project will provide the client the ability to create posts to get rid of free items or "freecycle".
With full CRUD functionality to post, this API as a stretch goal will be able to host user uploaded photos of the items posted. 
<br>
<br>

### 🛠 Built With
* [Visual Studio Code](https://code.visualstudio.com/)
* [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
* [ASP.NET Core MVC](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-3.1)
* [Swagger: SquashBuckle v5.6.3](https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-nswag?view=aspnetcore-3.1&tabs=visual-studio)
* [Postman](postman.com)

------------------------------

## Installation Requirements:

### 1) Install .NET Core
* On macOS:
  * [Click here](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.106-macos-x64-installer)
* On Windows 10:
  * [Click here](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.203-windows-x64-installer)

### 2) Install dotnet script
 * Enter the command ``dotnet tool install -g dotnet-script`` in Terminal.

### 4) Install Postman
* [Download and install Postman](https://www.postman.com/downloads/).

### 5) VS Code

  * i) Code Editor:
     * [Download Here](https://www.npmjs.com/)
  * ii) Download and install into applications folder

______________________________________________________________________________________
<br>

## Setup:

  #### i) Cloning

  1) Navigate to project directory
  2) Click the green 'Clone or download' button to copy URL.
  3) Navigate to local repository to host the file.
  4) Use the following command to clone the repository to your local device: 
  * $ git clone '___*Copied URL*___'
  5) Run the following command to enter project: 
  - $ cd '___*Copied URL*___'

  #### ii) AppSettings

  1) Create a new file in the project directory named `appsettings.json`
  2) Add in the following code snippet to the new appsettings.json file and update fields in brackets:
  
  ```
    "AllowedHosts": "*",
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=[Misc_Number];database=[project_api];uid=root;pwd=[YourPassword];"
    }
  ```

  #### Launch the API
  1) Navigate to project directory
  2) Run the command `dotnet run` to have access to the API in Postman or browser.

------------------------------

## 🛰️ API Documentation
Explore the API endpoints in Postman or a browser. You will not be able to utilize authentication in a browser.

### Using Swagger Documentation 
#### i) To launch the project API with Swashbuckle, run the following command in the Terminal:
`dotnet run`
 #### ii) Click on / hard code the following URL into your browser: `http://localhost:5000/swagger`
________________________________________________
________________________________________________

### Endpoints
Base URL: `https://localhost:5000`

#### HTTP Request Structure
```
GET /api/{project}
POST /api/{project}
GET /api/{project}/{id}
PUT /api/{project}/{id}
DELETE /api/{project}/{id}
```

#### Example Query w/ swagger:
```
https://localhost:5000/swagger/index.html
```

#### Sample JSON Response
```
{
    "Id": 14,
    "Name": "John Doe",
    "Street Address": "1111 Epicodus ln NE",
    "City": "Portland",
    "State": "Oregon"
    "Age: "34",
}
```

..........................................................................................


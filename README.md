# Full Stack Web Application

## Project Overview

This project is a Full Stack Web Application built with:

Backend: .NET 6 (ASP.NET Core)  
ORM: Entity Framework  
Frontend: React  

The backend exposes a REST API and the frontend consumes the API to display and manage data.

---

# Technologies

## Backend

- .NET 6
- ASP.NET Core Web API
- Entity Framework
- Swagger

## Frontend

- React
- NPM
- MUI (Material UI)

---

# Project Structure

Backend: ASP.NET Core Web API project  
Frontend: React application  

The SQL file required to create the database is located **in the root folder of the project** (not inside another folder).

---

# Running the Backend

1. Open the backend project in **Visual Studio**.

2. Run the project.

Usually Visual Studio will automatically restore the required packages and start the server.

3. The API will run locally.

Swagger can be accessed at:

https://localhost:7232/swagger/index.html

---

# Running the Frontend

Open a terminal inside the **React project folder** and run the following commands.

Install dependencies:

```
npm install
```

Install Material UI:

```
npm install @mui/material @emotion/react @emotion/styled
```

Run the development server:

```
npm run dev
```

After running the command, the React application will start locally.

---

# Database Setup

The SQL file required for the database is located in the **main project directory**.

Steps:

1. Open the SQL file.
2. Run it in SQL Server Management Studio (SSMS).
3. This will create the required database and tables.

---

# Notes

- The backend must be running before using the frontend.
- The frontend communicates with the API running locally.

API base example:

https://localhost:7232

---

# Author

Project created as a learning Full Stack project using .NET and React.
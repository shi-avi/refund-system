# Refund System

Full Stack application for managing refund requests.

## Technologies

### Backend
- .NET 6
- ASP.NET Core Web API
- Entity Framework Core

### Frontend
- React
- MUI (Material UI)

---

# How to Run the Project

Follow the steps below to run the project locally.

---

# 1. Clone the Repository

First, download the project from GitHub using Git:

```bash
git clone https://github.com/shi-avi/refund-system.git
cd refund-system
```

---

# 2. Create the Database

In the root folder of the project there is a SQL file:

```
init_db.sql
```

Open this file using **SQL Server Management Studio (SSMS)** and run it.

This script will create the database required for the project.

Database name:

```
RefundSystemDB
```

---

# 3. Configure the Backend

Open the backend project in **Visual Studio**.

Backend project folder:

```
RefundSystemApi
```

Open the file:

```
appsettings.json
```

Update the connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=RefundSystemDB;Trusted_Connection=True;MultipleActiveResultSets=true;"
}
```

Replace:

```
YOUR_SERVER_NAME
```

with the name of your local SQL Server.

Example:

```
Server=DESKTOP-XXXX
```

---

# 4. Run the Backend

Run the backend project using **Visual Studio**.

After running the project, the API will start locally.

Swagger documentation should be available at:

```
https://localhost:7232/swagger/index.html
```

---

# 5. Run the Frontend (React)

Navigate to the frontend folder:

```
refund-system-app
```

Install project dependencies:

```bash
npm install
```

Install Material UI:

```bash
npm install @mui/material @emotion/react @emotion/styled
```

Run the React application:

```bash
npm run dev
```

The application will start locally in the browser.

---

# Notes

- Make sure SQL Server is running locally.
- Make sure the backend is running before starting the frontend.
- Verify that the connection string in `appsettings.json` points to your local SQL Server.

---

# Repository

https://github.com/shi-avi/refund-system.git
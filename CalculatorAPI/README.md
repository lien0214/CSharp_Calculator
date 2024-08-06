# Calculator API

## Overview

CalculatorAPI is an ASP.NET Core web backend service. It provides API endpoints that handle calculator button inputs, processes these inputs through the Calculator Core, and returns the calculation results.

## Features

- **Handling Button Input**: Maps button text to corresponding actions (e.g., digits, operators, parentheses).
- **Error Handling**: Returns an error message when input is invalid.

## Running the Application

```bash
git clone <repository-url>
cd CalculatorAPI
dotnet build
dotnet run
```

The API will start at http://localhost:5000. You can use the Swagger UI to call the API at http://localhost:5000/swagger.

## API Usage

### Endpoint: `POST /calculator`

- **Description**: Processes button clicks in the calculator.
- **Request Body**: A string representing the button text (e.g., "1", "+", "CE").
- **Responses**:
  - `200 OK`: Successful operation with the result of the button click.
  - `400 Bad Request`: Invalid button text specified.

### Example

```bash
curl -X POST "http://localhost:5000/calculator" -H "Content-Type: application/json" -d "\"1\""
```
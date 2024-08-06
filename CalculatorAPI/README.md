# Calculator API

## Overview

CalculatorAPI 是一個 ASP.NET Core 網絡後端服務。它提供了 API 端點，處理計算器按鈕輸入，通過 Calculator Core 處理這些輸入，並返回計算結果。

## Features

- **處理 Button 輸入**: 將 button text 對應到相應的操作 (e.g., digits, operators, parentheses)。
- **Error Handling**: 當輸入無效，返回錯誤消息。

## Running the Application

   ```bash
   git clone <repository-url>
   cd CalculatorAPI
   dotnet build
   dotnet run
   ```

API 將在 http://localhost:5000 啟動。可以在 http://localhost:5000/swagger 使用 Swagger UI 呼叫 API 。

## API Usage

### Endpoint: `POST /calculator`

- **Description**: 處理計算器中的按鈕點擊。
- **Request Body**: A string representing the button text (e.g., "1", "+", "CE").
- **Responses**:
  - `200 OK`: Successful operation with the result of the button click.
  - `400 Bad Request`: Invalid button text specified.

### Example

```bash
curl -X POST "http://localhost:5000/calculator" -H "Content-Type: application/json" -d "\"1\""
```


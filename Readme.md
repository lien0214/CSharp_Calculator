# Calculator

**Calculator** 是一個完整的計算器應用程式，包含 API 、 Core 和 UI 。專案由以下部分組成：

1. [CalculatorAPI](CalculatorAPI/README.md) - 提供計算器功能的 API 端點
2. [CalculatorCore](CalculatorCore/README.md) - 包含計算器的核心邏輯
3. [CalculatorForm](CalculatorForm/README.md) - 用戶端應用程式，提供計算器的圖形用戶介面

## Quick Start

### 安裝

要運行這個專案，您需要在您的機器上安裝 .NET SDK。

### 運行專案的步驟

1. 將此存儲庫克隆到您的本地機器：
```sh
git clone http://192.168.10.147:8080/lien0214/calculator.git
cd ./Calculator05/
```
2. 還原 dotnet 依賴項：
```sh
dotnet restore
```
3. 運行測試以確保一切正確設置：
```sh
dotnet test
```
4. 運行專案：
```sh
dotnet run
```

---

# 🌎 Exchange Rate Converter

An application that converts currency from one country to another based on real-time exchange rates fetched from the 🌐 [ExchangeRate-API](https://www.exchangerate-api.com/).

## 📋 Table of Contents
- [🔍 Overview](#-overview)
- [✨ Features](#-features)
- [📁 Project Structure](#-project-structure)
- [🚀 Getting Started](#-getting-started)
- [⚙️ Configuration](#️-configuration)
- [🛠 Usage](#-usage)
- [💻 Technologies Used](#-technologies-used)
- [📄 License](#-license)

## 🔍 Overview
The **Exchange Rate Converter** is a console application that reads currency details from a file and performs currency conversion calculations using live exchange rates.

## ✨ Features
- 📄 Reads input data from a text file.
- 🔗 Retrieves exchange rates via API for specified currencies.
- 💸 Converts values based on the latest exchange rates.
- 🖨 Prints the calculated results to the console.

## 📁 Project Structure
- **Program.cs** - The entry point of the application.
- **Utilities.cs** - A singleton class for configuration constants.
- **ReadFile.cs** - Reads and processes input file data.
- **ExchangeData.cs** - Retrieves exchange rate data from an external API.
- **ExchangeCalculate.cs** - Performs the currency conversion calculations.
- **Controller.cs** - Orchestrates file reading, exchange rate retrieval, and conversion processes.

## 🚀 Getting Started

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) (version 4.7.2 or higher)
- [ExchangeRate-API Key](https://www.exchangerate-api.com/) 🔑 (to fetch exchange rates)

### Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/exchange-rate-converter.git
   cd exchange-rate-converter
   ```

2. Restore dependencies (if applicable):
   ```bash
   dotnet restore
   ```

## ⚙️ Configuration
In the project’s root directory, create a `appsettings.json` file with the following structure to store your API key:

```json
{
  "AppSettings": {
    "API_KEY": "your_api_key_here"
  }
}
```

## 🛠 Usage

### Run the Application
Run the following command in your terminal, specifying the file with currency details:
```bash
dotnet run -- "path/to/your/input_file.txt"
```

### 📄 Input File Format
The input file should have the following format:
1. Line 1: Country code of the currency to convert from (e.g., USD)
2. Line 2: Country code of the currency to convert to (e.g., EUR)
3. Remaining lines: Values to be converted

Example:
```
USD
EUR
100
250
50
```

## Example
For the input file above, the program outputs the equivalent EUR values for each USD amount based on current rates.

## 💻 Technologies Used
- C#
- .NET 4.7.2
- ExchangeRate-API
- Newtonsoft.Json for JSON parsing

## 📄 License
This project is licensed under the MIT License.

---

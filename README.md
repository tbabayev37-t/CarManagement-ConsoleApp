# 🚗 Car Dealership & Management System

A robust C# Console Application featuring structured sub-menus, persistent JSON File I/O storage, an integrated banking system, and comprehensive unit tests.

---

## 🛠️ Tech Stack & Architecture
* **Language:** C# (.NET 10)
* **Architecture:** Separation of Concerns (UI, Business Logic, Helpers, Exceptions)
* **Data Persistence:** JSON serialization/deserialization via `System.Text.Json` (`FileHelper`)
* **Testing:** Automated unit testing using **xUnit** (`CarDealershipTest`)
* **Core Features:**
  * **Car Management & Sales:** Add, view, delete, filter, sort, and sell cars with automatic bank updates.
  * **Rent a Car:** Dedicated rental workflow managing availability and rental statuses (`IsRented`).
  * **Bank System:** Tracks financial transactions, deposits, withdrawals, and balances.

---

## 📂 Project Structure
```text
CarDealershipFull/
│
├── Exceptions/            # Custom exceptions (CarNotFoundException, InsufficientFundsException)
├── Helpers/
│   └── FileHelper.cs      # Handles local JSON persistence (cars.json)
├── Models/
│   ├── Car.cs             # Car entity
│   ├── Bank.cs            # Bank account logic
│   └── Transaction.cs     # Financial records
├── Services/
│   └── DealershipService.cs # Centralized business logic
├── Program.cs             # Console User Interface (Sub-menus)
└── cars.json              # Persistent data store

CarDealershipTest/         # xUnit Test Project
├── BankTests.cs
└── DealershipServiceTests.cs

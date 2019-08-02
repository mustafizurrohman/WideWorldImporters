WideWorldImporters WebAPI

- Uses **OData v4**
- Custom Exception Handler Middleware
    - Logs exception in Background without blocking the thread
- Logging using **NLog**
- Tests using **XUnit**
- **Hangfire** for Background Tasks

- **Authentication Provider** is **work in progress**. It may not have the best practices built in.
Authorization Controller **must never be** a part of public API. Only for testing.

- **Clean Coding** and **SOLID** principles


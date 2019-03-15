# AzureFunctionsDependencyInjection
This is a sample solution to show how to do dependency injection in Azure Functions.  The project is structured in a way to achieve isolation of dependencies from the Azure Function app.

## Requirements
Azure Functions SDK v2
Visual Studio 2017

## Techonology Used
NetCore.AutoRegisterDi [https://github.com/JonPSmith/NetCore.AutoRegisterDi]

## Overview
Now that Azure Functions SDK supports defining functions within a non-static class, we can inject dependencies into those class instances.

## Project Structure
 - Adapters: Contains a service implementation.  You would normally put your adapters here that connect to external systems, such as databases, logging, HTTP calls, etc.
 - Common: Defines the service interfaces.  You would normall put your business logic here.
 - Dependencies: This is the middle layer between the Function app and the adapters.  Contains the service registration code.
 - FunctionApp: Our Azure Function application which contains a single function and some injected services.


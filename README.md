# Jodo.Api.Client

A .NET client library for interacting with the Jodo API.

## Installation

This project is not yet published to NuGet. To use it, you can include the `Jodo.Api.Client.csproj` in your solution and add a project reference.

## Usage

### 1. Configuration

In your `appsettings.json`, add a section for the Jodo API configuration:

```json
"JodoApi": {
  "ApiKey": "YOUR_API_KEY",
  "ApiSecret": "YOUR_API_SECRET",
  "ApiHost": "ext.devtest1.jodopay.com"
}
```

### 2. Dependency Injection

In your `Startup.cs` or `Program.cs` (for .NET 6+), register the Jodo API client:

```csharp
using Jodo.Api.Client.Extensions;

// ...

public void ConfigureServices(IServiceCollection services)
{
    // ...
    services.AddJodoApiClient(Configuration);
    // ...
}
```

### 3. API Client Usage

Inject the `IJodoApiClient` into your services or controllers:

```csharp
using Jodo.Api.Client.Services;
using Jodo.Api.Client.Models.User;

public class MyService
{
    private readonly IJodoApiClient _jodoApiClient;

    public MyService(IJodoApiClient jodoApiClient)
    {
        _jodoApiClient = jodoApiClient;
    }

    public async Task<string> RegisterNewUser(string name, string phone, string email)
    {
        var request = new RegisterUserRequest
        {
            Name = name,
            Phone = phone,
            Email = email
        };

        var response = await _jodoApiClient.RegisterUser(request);
        return response.RegistrationId;
    }
}
```

## API Coverage

This library covers the following Jodo API groups:

*   User APIs
*   Student APIs
*   Pull APIs
*   Pay Order APIs
*   Payment Link APIs
*   Webhook APIs
*   Meta APIs
*   UAT Simulation APIs

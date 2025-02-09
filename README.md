# Trophy .NET Library

The official [Trophy](https://trophy.so) .NET library.

Trophy provides APIs and tools for adding gamification to your application, keeping users engaged
through rewards, achievements, streaks, and personalized communication.

## Installation

Using the [.NET Core command-line interface (CLI) tools](https://docs.microsoft.com/en-us/dotnet/core/tools/):

```sh
dotnet add package Trophy
```

Using the [NuGet Command Line Interface (CLI)](https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference):

```sh
nuget install Trophy
```

Using the [Package Manager Console](https://docs.microsoft.com/en-us/nuget/tools/package-manager-console):

```powershell
Install-Package Trophy
```

From within Visual Studio:

1. Open the Solution Explorer.
2. Right-click on a project within your solution.
3. Click on _Manage NuGet Packages..._
4. Click on the _Browse_ tab and search for "Trophy".
5. Click on the Trophy package, select the appropriate version in the
   right-tab and click _Install_.

## Documentation

See the [Trophy API Docs](https://trophy.docs.buildwithfern.com/overview/introduction) for more
information.

## Usage

The package needs to be configured with your account's API key, which is available in the Trophy
web interface. Set the API key with the following:

```csharp
using Trophy;

var trophy = new TrophyApiClient("your-api-key");
```

Then you can access the Trophy API through the `trophy` client. For example, you can send a metric
event:

```csharp
using Trophy.Models.Metrics;
using Trophy.Models.Metrics.Requests;

var request = new MetricsEventRequest
{
    User = new EventRequestUser
    {
        Id = "18",
        Email = "jk.rowling@harrypotter.com"
    },
    Value = 750
};

trophy.Metrics.Event("words-written", request);
```

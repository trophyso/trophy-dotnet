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

## Usage

The package needs to be configured with your account's API key, which is available in the Trophy
web interface. Set the API key with the following:

```csharp
using TrophyApi;

var trophy = new TrophyApiClient("YOUR_API_KEY");
```

Then you can access the Trophy API through the `trophy` client. For example, you can send a metric
event:

```csharp
var user = new EventRequestUser {
   Id = "18",
   Email = "jk.rowling@harrypotter.com"
};

var request = new MetricsEventRequest {
   User = user,
   Value = 750
};

await trophy.Metrics.EventAsync("words-written", request);
```

## Documentation

See the [Trophy API Docs](https://docs.trophy.so) for more
information on the accessible endpoints.

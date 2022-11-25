# handy
![Nuget](https://img.shields.io/nuget/v/Handy.Net)
![Downloads](https://img.shields.io/nuget/dt/Handy.Net)

Handy Typed Client

## Installation
```bash
dotnet add package Handy.Net
```

## Basic usage
The following code makes the device move for 10 seconds.

```csharp
using Handy;

var connectionKey = "<Your key>";

var baseUrl = new Uri("https://www.handyfeeling.com/api/handy/v2/");
var client = new HttpClient();

client.BaseAddress = baseUrl;
client.DefaultRequestHeaders.Add("X-Connection-Key", connectionKey);

var handy = new HandyClient(client);

await handy.StartMotionAsync();

await Task.Delay(10000);

await handy.StopMotionAsync();
```
<h1 align="center" style="border-bottom: none;">Casdoor .NET SDK Samples</h1>

Here are Casdoor .NET SDK samples for **[casdoor-dotnet-sdk](https://github.com/casdoor/casdoor-dotnet-sdk)**.

| Sample Name                          | Dependencies      | **Description**                |
| ------------------------------------ | ----------------- | ------------------------------ |
| <a href="#ConsoleApp">ConsoleApp</a> | .NET 6.0 or newer | Sample of a simple console app |
| <a href="#MvcApp">MvcApp</a>         | .NET 6.0 or newer | Sample of a MVC webapp         |
| <a href="#MvcApi">MvcApi</a>         | .NET 7.0 or newer | Sample of a MVC webapi         |

## <a id="ConsoleApp">ConsoleApp</a>

This sample simply shows how to use [Casdoor.Client](https://github.com/casdoor/casdoor-dotnet-sdk/tree/master/src/Casdoor.Client) package. It is an API client implementation for the Casdoor, used to call the Casdoor APIs.

### Quickstart

```
git clone https://github.com/casdoor/casdoor-dotnet-sdk-example.git
cd casdoor-dotnet-sdk-example
dotnet run --project ConsoleApp
```

Some information will be displayed on the console, which is from the `Program.cs` file and has been processed by Casdoor.

### Configuration

Now open `Program.cs` file and you can see the following code:

```c#
var httpClient = new HttpClient();
var options = new CasdoorOptions
{
    Endpoint = "https://door.casdoor.com",
    OrganizationName = "casbin",
    ApplicationName = "app-build-in",
    ApplicationType = "native",
    ClientId = "b800a86702dd4d29ec4d",
    ClientSecret = "1219843a8db4695155699be3a67f10796f2ec1d5",
    CallbackPath = "/callback",
    RequireHttpsMetadata = true,
    Scope = "openid profile email"
};
var client = new CasdoorClient(httpClient, options);
```

The meanings of some fields are explained as follows:

| Name                 | Must | Description                                                  |
| -------------------- | ---- | ------------------------------------------------------------ |
| Endpoint             | Yes  | Your Casdoor host.                                           |
| OrganizationName     | Yes  | The organization that the application belongs to.            |
| ApplicationName      | Yes  | Your application name.                                       |
| ApplicationType      | Yes  | Your application type. Must be webapp, webapi or native.     |
| ClientId             | Yes  | Your OAuth client id.                                        |
| ClientSecret         | Yes  | Your OAuth client secret.                                    |
| CallbackPath         | No   | The callback path that the client will be redirected to after the user has authenticated. Default is "/casdoor/signin-callback". |
| RequireHttpsMetadata | No   | Whether requires https for Casdoor endpoint.                 |
| Scope                | No   | The scopes that the client is requesting.                    |

For more information, refer to https://github.com/casdoor/casdoor-dotnet-sdk/blob/master/README.md .

## <a id="MvcApp">MvcApp</a>

This sample shows how to use [Casdoor.AspNetCore](https://github.com/casdoor/casdoor-dotnet-sdk/tree/master/src/Casdoor.AspNetCore) package for Casdoor authentication. 

### Quickstart

```bash
git clone https://github.com/casdoor/casdoor-dotnet-sdk-example.git
cd casdoor-dotnet-sdk-example
dotnet run --project MvcApp
```

The default settings use the public demo Casdoor and Casnode configuration. Now Casdoor is listening on `http://localhost:5000` and `https://localhost:5001`, and you can open your browser and visit any of them.

![mvcapp1](docs/assets/mvcapp-login.png)

Input `admin` and `123` to sign in, or you can register a new account. 

### Configure your Casdoor

You can change the settings in the `appsettings.json` file according to the deployed Casdoor configuration. Here are relevant settings in this sample.

```json
"Casdoor": {
    "Endpoint": "https://door.casdoor.com",
    "OrganizationName": "casbin",
    "ApplicationName": "app-example",
    "ApplicationType": "webapp",
    "ClientId": "b800a86702dd4d29ec4d",
    "ClientSecret": "1219843a8db4695155699be3a67f10796f2ec1d5",
    "CallbackPath": "/callback",
    "RequireHttpsMetadata": false
},
```

The meanings of some fields are explained as follows:

| Name                 | Must | Description                                                  |
| -------------------- | ---- | ------------------------------------------------------------ |
| Endpoint             | Yes  | Your Casdoor host.                                           |
| OrganizationName     | Yes  | The organization that the application belongs to.            |
| ApplicationName      | Yes  | Your application name.                                       |
| ApplicationType      | Yes  | Your application type.                                       |
| ClientId             | Yes  | Your OAuth client id.                                        |
| ClientSecret         | Yes  | Your OAuth client secret.                                    |
| CallbackPath         | No   | The callback path that the client will be redirected to after the user has authenticated. Default is "/casdoor/signin-callback". |
| RequireHttpsMetadata | No   | Whether requires https for Casdoor endpoint.                 |

In addition, some launch settings are placed in the `Properties/launchSettings.json` file, such as the listening URLs `http://localhost:5000;https://localhost:5001`, to facilitate your use of this sample. This file is not necessary.

For more information, refer to https://github.com/casdoor/casdoor-dotnet-sdk/blob/master/README.md .

## <a id="MvcApi">MvcApi</a>

This sample shows how to use [Casdoor.AspNetCore](https://github.com/casdoor/casdoor-dotnet-sdk/tree/master/src/Casdoor.AspNetCore) package for Casdoor authentication. It consists of a WebApi authenticated by CasDoor and a console program that calls it.

### Quickstart

```bash
git clone https://github.com/casdoor/casdoor-dotnet-sdk-example.git
cd .\casdoor-dotnet-sdk-example\MvcApi
```

To run the Api:

```bash
dotnet run --project ApiSample
```

This Api comes from the Visual Studio example and after running it you will see the following:

```bash
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:7265
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5076
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: {Path}\casdoor-dotnet-sdk-example\MvcApi\ApiSample
```

To run the Caller:

```bash
dotnet run --project CallerSample
```

This caller will automatically get the token and call the aforementioned Api. If the message shown below appears after running, the call was successful.

```
token: {token.AccessToken}
API Response:
[{"date":"2023-08-09","temperatureC":-5,"temperatureF":24,"summary":"Warm"},{"date":"2023-08-10","temperatureC":6,"temperatureF":42,"summary":"Scorching"},{"date":"2023-08-11","temperatureC":45,"temperatureF":112,"summary":"Freezing"},{"date":"2023-08-12","temperatureC":29,"temperatureF":84,"summary":"Hot"},{"date":"2023-08-13","temperatureC":23,"temperatureF":73,"summary":"Mild"}]
```

### Configure your Casdoor

Almost identical to MvcApp, you can change the settings in the `appsettings.json` file according to the deployed Casdoor configuration. Here are relevant settings in this api sample.

```json
"CasDoor": {
    "Endpoint": "https://door.casdoor.com",
    "OrganizationName": "casbin",
    "ApplicationName": "app-example",
    "ApplicationType": "webapi",
    "ClientId": "b800a86702dd4d29ec4d",
    "ClientSecret": "1219843a8db4695155699be3a67f10796f2ec1d5",
    "CallbackPath": "/callback",
    "RequireHttpsMetadata": false
  },
```

The meanings of some fields are explained as follows:

| Name                 | Must | Description                                                  |
| -------------------- | ---- | ------------------------------------------------------------ |
| Endpoint             | Yes  | Your Casdoor host.                                           |
| OrganizationName     | Yes  | The organization that the application belongs to.            |
| ApplicationName      | Yes  | Your application name.                                       |
| ApplicationType      | Yes  | Your application type.                                       |
| ClientId             | Yes  | Your OAuth client id.                                        |
| ClientSecret         | Yes  | Your OAuth client secret.                                    |
| CallbackPath         | No   | The callback path that the client will be redirected to after the user has authenticated. Default is "/casdoor/signin-callback". |
| RequireHttpsMetadata | No   | Whether requires https for Casdoor endpoint.                 |
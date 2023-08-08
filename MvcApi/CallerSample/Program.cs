using Casdoor.Client;
using Microsoft.IdentityModel.Logging;

var httpClientApi = new HttpClient();
var options = new CasdoorOptions
{
    Endpoint = "https://door.casdoor.com",
    OrganizationName = "casbin",
    ApplicationName = "app-example",
    ApplicationType = "native", // webapp, webapi or native
    ClientId = "b800a86702dd4d29ec4d",
    ClientSecret = "1219843a8db4695155699be3a67f10796f2ec1d5",
};

var client = new CasdoorClient(httpClientApi, options);

IdentityModelEventSource.ShowPII = true;
var token = await client.RequestPasswordTokenAsync("admin", "123");
if (token.AccessToken is null)
{
    Console.WriteLine("Failed to get the token.");
    return;
}
Console.WriteLine($"token: {token.AccessToken}");

string apiUrl = "https://localhost:7265/WeatherForecast";
HttpClient httpClientCaller = new HttpClient();

Console.ForegroundColor = ConsoleColor.Blue;

try
{
    httpClientCaller.DefaultRequestHeaders.Add("Authorization", $"Bearer {token.AccessToken}");

    HttpResponseMessage response = await httpClientCaller.GetAsync(apiUrl);

    if (response.IsSuccessStatusCode)
    {
        string content = await response.Content.ReadAsStringAsync();
        Console.WriteLine("API Response:");
        Console.WriteLine(content);
    }
    else
    {
        Console.WriteLine("API request failed with status code:" + response.StatusCode);
    }
}
catch (HttpRequestException ex)
{
    Console.WriteLine("HTTP request exception:" + ex.Message);
}

Console.ResetColor();
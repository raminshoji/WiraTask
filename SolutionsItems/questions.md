1. How much time did you spend on this task?
 If you had more time, what improvements or additions would you make?

I spent 4 days working this exercise
If I had more time, I would add CQRS using MediatR, and implement authentication and authorization.
More comprehensive error handling and custom exceptions

2. What is the most useful feature recently added to your favorite programming language?
 Please include a code snippet to demonstrate how you use it.

Primary Constructor (C# 12)
// Before C# 12

public class WeatherService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    public WeatherService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiKey = configuration["ApiKey"];
    }
}

// With C# 12 Primary Constructor
public class WeatherService(HttpClient httpClient, IConfiguration configuration) 
    : IWeatherService
{
    private readonly string _apiKey = configuration["ApiKey"];
    public async Task<WeatherData> GetWeatherAsync(string city)
    {
        var response = await httpClient.GetAsync($"api/weather/{city}");
        return await response.Content.ReadFromJsonAsync<WeatherData>();
    }
}
// Collection expressions (C# 12)
int[] array = [1, 2, 3, 4, 5];
List<string> names = ["John", "Jane", "Bob"];

// Pattern matching enhancements
if (weatherData is { Temperature: > 30, Humidity: > 70 })
{
    Console.WriteLine("Hot and humid!");
}


3. How do you identify and diagnose a performance issue in a production environment?
 Have you done this before?

i have never been doing this before
but it should  be related to logging and etc

4. What’s the last technical book you read or technical conference you attended?
 What did you learn from it?

C# 10 Quick Syntax Reference: A Pocket Guide to the Language, APIs, and Library" by Mikael Olsson. 
i learn how to code in C#


5. What’s your opinion about this technical test?

 Practical and relevant to real-world scenarios
 Tests multiple skills: API design, external integrations, testing
 Allows flexibility in implementation approach
 Includes both coding and conceptual questions

6. Please describe yourself using JSON format.

{
  "personalInformation": {
    "name": "ramin",
    "lastname": "shojaei",
    "nationalCode": 0480904235,
    "role": "software engineering internship"
   },
  "technicalSkills": {
    "languages": ["C#","SQL"],
    "frameworks": [".NET 8","Entity Framework"],
    "databases": ["SQL Server"]
  },
  "contact": {
    "phoneNumber": "09379071800",
    "address": "Tehran,iran"
  }
}



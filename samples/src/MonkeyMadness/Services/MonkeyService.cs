using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MonkeyMadness.Data;

namespace MonkeyMadness.Services;

public class MonkeyService : IMonkeyService
{
    private readonly HttpClient httpClient;

    public MonkeyService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<List<Monkey>> GetMonkeysAsync()
    {
        var response = await this.httpClient.GetAsync("monkeys.json");
        response.EnsureSuccessStatusCode();
        var results = await response.Content.ReadFromJsonAsync<List<Monkey>>();
        if (results == null)
        {
            throw new InvalidOperationException("No monkeys returned!");
        }
        return results;
    }
}

using System;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;

namespace AppWebAssembly.Helpers;

public class HttpClientHelper
{
    private readonly HttpClient _httpClient;

    public HttpClientHelper(HttpClient httpClient){
        _httpClient = httpClient;
    }

    public async Task<T> GetTAsync<T>(string url){
        var response = await _httpClient.GetAsync(url);

        response.EnsureSuccessStatusCode();
        var jsonResponse = await response.Content.ReadAsStreamAsync();
        return JsonSerializer.Deserialize<T>(jsonResponse);
    }

    public async Task<T> PostAsync<T>(string url, T data){
        var jsonData =  JsonSerializer.Serialize(data);
        var content = new StringContent(jsonData,Encoding.UTF8,"application/json");
        var response = await _httpClient.PostAsJsonAsync(url,content);
        response.EnsureSuccessStatusCode();
        var jsonResponse = await response.Content.ReadAsStreamAsync();
        return JsonSerializer.Deserialize<T>(jsonResponse);
    }
}

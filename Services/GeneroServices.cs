using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using BibliotecaBlazor.Models;

public class GeneroService
{
    private readonly HttpClient _httpClient;

    public GeneroService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Genero>> GetGeneros()
    {
        return await _httpClient.GetFromJsonAsync<List<Genero>>("api/Generos");
    }

    public async Task<Genero> GetGenero(int id)
    {
        return await _httpClient.GetFromJsonAsync<Genero>($"api/Generos/{id}");
    }

    public async Task AddGenero(Genero genero)
    {
        await _httpClient.PostAsJsonAsync("api/Generos", genero);
    }

    public async Task UpdateGenero(Genero genero)
    {
        await _httpClient.PutAsJsonAsync($"api/Generos/{genero.ID}", genero);
    }

    public async Task<HttpResponseMessage> DeleteGenero(int id)
    {
      return   await _httpClient.DeleteAsync($"api/Generos/{id}");
    }
}
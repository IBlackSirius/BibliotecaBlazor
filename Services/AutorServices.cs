using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using BibliotecaBlazor.Models;
using System.Collections.ObjectModel;

public class AutorService
{
    private readonly HttpClient _httpClient;

    public AutorService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders
        .Accept
        .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

    }

    public async Task<List<Autor>> GetAutores()
    {
        return await _httpClient.GetFromJsonAsync<List<Autor>>("api/Autores");
    }

    public async Task<Autor> GetAutor(int id)
    {
        return await _httpClient.GetFromJsonAsync<Autor>($"api/Autores/{id}");
    }

    public async Task AddAutor(Autor autor)
    {        
        await _httpClient.PostAsJsonAsync("api/Autores", autor);
    }

    public async Task UpdateAutor(Autor autor)
    {   
        await _httpClient.PutAsJsonAsync($"api/Autores/{autor.ID}", autor);        
    }

    public async Task<HttpResponseMessage> DeleteAutor(int id)
    {
        return await _httpClient.DeleteAsync($"api/Autores/{id}");
    }
}
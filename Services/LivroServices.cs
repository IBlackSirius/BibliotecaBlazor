using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using BibliotecaBlazor.Models;

public class LivroService
{
    private readonly HttpClient _httpClient;

    public LivroService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Livro>> GetLivros()
    {
        return await _httpClient.GetFromJsonAsync<List<Livro>>("api/Livros");
    }

    public async Task<Livro> GetLivro(int id)
    {
        return await _httpClient.GetFromJsonAsync<Livro>($"api/Livros/{id}");
    }

    public async Task<HttpResponseMessage> AddLivro(Livro livro)
    {
        return await _httpClient.PostAsJsonAsync("api/Livros", livro);
        
    }

    public async Task UpdateLivro(Livro livro)
    {
        await _httpClient.PutAsJsonAsync($"api/Livros/{livro.ID}", livro);
    }

    public async Task DeleteLivro(int id)
    {
        await _httpClient.DeleteAsync($"api/Livros/{id}");
    }
}

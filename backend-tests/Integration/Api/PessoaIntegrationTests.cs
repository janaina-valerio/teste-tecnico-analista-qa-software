using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Application.DTOs;
using MinhasFinancas.Infrastructure.Data;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace MinhasFinancas.Tests.Integration.Api;

internal class PessoaIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public PessoaIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(d =>
                    d.ServiceType == typeof(DbContextOptions<MinhasFinancasDbContext>));

                if (descriptor != null)
                    services.Remove(descriptor);

                services.AddDbContext<MinhasFinancasDbContext>(options =>
                    options.UseInMemoryDatabase("TestDb_Pessoa"));
            });
        });

        _client = _factory.CreateClient();
    }

    [Fact]
    public async Task CriarPessoa_ComIdadeValida_DeveSerCriada()
    {
        var dto = new CreatePessoaDto
        {
            Nome = "Carlos Silva",
            DataNascimento = DateTime.Today.AddYears(-28)
        };

        var response = await _client.PostAsJsonAsync("/api/v1.0/pessoas", dto);

        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    [Fact]
    public async Task DeletarPessoa_DeveRetornarNoContent()
    {
        // Arrange
        var pessoa = await CriarPessoaAsync("Pessoa Para Deletar", -30);

        // Act
        var response = await _client.DeleteAsync($"/api/v1.0/pessoas/{pessoa.Id}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task DeletarPessoa_Inexistente_DeveRetornarNotFound()
    {
        var response = await _client.DeleteAsync($"/api/v1.0/pessoas/{Guid.NewGuid()}");

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task DeletarPessoa_ComTransacoes_DeveDeletarPessoa_MasTransacoesFicamOrfas()
    {
        // Arrange
        var pessoa = await CriarPessoaAsync("Pessoa Com Transacao", -35);
        var categoria = await CriarCategoriaReceitaAsync();

        // Cria uma transação para essa pessoa
        await CriarTransacaoAsync(pessoa.Id, categoria.Id, 1500);

        // Act - Deleta a pessoa
        var deleteResponse = await _client.DeleteAsync($"/api/v1.0/pessoas/{pessoa.Id}");
        deleteResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);

        // Assert - Verifica que as transações ainda existem (comportamento atual da aplicação)
        var transacoesResponse = await _client.GetAsync("/api/v1.0/transacoes");
        transacoesResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await transacoesResponse.Content.ReadFromJsonAsync<PagedResult<TransacaoDto>>();
        content!.Items.Should().NotBeEmpty(); // Pelo menos a transação que criamos deve continuar
    }

    // ====================== Métodos Auxiliares ======================

    private async Task<PessoaDto> CriarPessoaAsync(string nome, int anos)
    {
        var dto = new CreatePessoaDto
        {
            Nome = nome,
            DataNascimento = DateTime.Today.AddYears(anos)
        };

        var response = await _client.PostAsJsonAsync("/api/v1.0/pessoas", dto);
        return (await response.Content.ReadFromJsonAsync<PessoaDto>())!;
    }

    private async Task<CategoriaDto> CriarCategoriaReceitaAsync()
    {
        var dto = new CreateCategoriaDto
        {
            Descricao = "Categoria Teste",
            Finalidade = Categoria.EFinalidade.Receita
        };

        var response = await _client.PostAsJsonAsync("/api/v1.0/categorias", dto);
        return (await response.Content.ReadFromJsonAsync<CategoriaDto>())!;
    }

    private async Task CriarTransacaoAsync(Guid pessoaId, Guid categoriaId, decimal valor)
    {
        var dto = new CreateTransacaoDto
        {
            Descricao = "Transacao de Teste",
            Valor = valor,
            Tipo = Transacao.ETipo.Receita,
            CategoriaId = categoriaId,
            PessoaId = pessoaId,
            Data = DateTime.Today
        };

        await _client.PostAsJsonAsync("/api/v1.0/transacoes", dto);
    }
}
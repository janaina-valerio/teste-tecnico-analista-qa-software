using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Application.DTOs;
using MinhasFinancas.Infrastructure.Data;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace MinhasFinancas.Tests.Integration.Api;

internal class TransacaoIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public TransacaoIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                // Substitui o banco SQLite por InMemory só para testes
                var descriptor = services.SingleOrDefault(d =>
                    d.ServiceType == typeof(DbContextOptions<MinhasFinancasDbContext>));

                if (descriptor != null)
                    services.Remove(descriptor);

                services.AddDbContext<MinhasFinancasDbContext>(options =>
                    options.UseInMemoryDatabase("TestDb_Transacoes"));
            });
        });

        _client = _factory.CreateClient();
    }

    [Fact]
    public async Task CriarTransacao_MenorDeIdade_Receita_DeveRetornarBadRequest()
    {
        // Arrange
        var pessoa = await CriarPessoaMenorAsync();
        var categoria = await CriarCategoriaReceitaAsync();

        var dto = new CreateTransacaoDto
        {
            Descricao = "Salário Teste",
            Valor = 2500,
            Tipo = Transacao.ETipo.Receita,
            CategoriaId = categoria.Id,
            PessoaId = pessoa.Id,
            Data = DateTime.Today
        };

        // Act
        var response = await _client.PostAsJsonAsync("/api/v1.0/transacoes", dto);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var content = await response.Content.ReadAsStringAsync();
        content.Should().ContainAny("menor", "18", "receita");
    }

    [Fact]
    public async Task CriarTransacao_MaiorDeIdade_Receita_DeveSerCriadaComSucesso()
    {
        var pessoa = await CriarPessoaMaiorAsync();
        var categoria = await CriarCategoriaReceitaAsync();

        var dto = new CreateTransacaoDto
        {
            Descricao = "Freelance Janeiro",
            Valor = 4200,
            Tipo = Transacao.ETipo.Receita,
            CategoriaId = categoria.Id,
            PessoaId = pessoa.Id,
            Data = DateTime.Today
        };

        var response = await _client.PostAsJsonAsync("/api/v1.0/transacoes", dto);

        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    [Fact]
    public async Task CriarTransacao_CategoriaDespesa_Receita_DeveFalhar()
    {
        var pessoa = await CriarPessoaMaiorAsync();
        var categoriaDespesa = await CriarCategoriaDespesaAsync();

        var dto = new CreateTransacaoDto
        {
            Descricao = "Erro Categoria",
            Valor = 300,
            Tipo = Transacao.ETipo.Receita,
            CategoriaId = categoriaDespesa.Id,
            PessoaId = pessoa.Id,
            Data = DateTime.Today
        };

        var response = await _client.PostAsJsonAsync("/api/v1.0/transacoes", dto);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    // ====================== Métodos Auxiliares ======================

    private async Task<PessoaDto> CriarPessoaMenorAsync()
    {
        var dto = new CreatePessoaDto
        {
            Nome = "João Teste Menor",
            DataNascimento = DateTime.Today.AddYears(-16)
        };

        var response = await _client.PostAsJsonAsync("/api/v1.0/pessoas", dto);
        return (await response.Content.ReadFromJsonAsync<PessoaDto>())!;
    }

    private async Task<PessoaDto> CriarPessoaMaiorAsync()
    {
        var dto = new CreatePessoaDto
        {
            Nome = "Maria Teste Adulta",
            DataNascimento = DateTime.Today.AddYears(-28)
        };

        var response = await _client.PostAsJsonAsync("/api/v1.0/pessoas", dto);
        return (await response.Content.ReadFromJsonAsync<PessoaDto>())!;
    }

    private async Task<CategoriaDto> CriarCategoriaReceitaAsync()
    {
        var dto = new CreateCategoriaDto
        {
            Descricao = "Receita Teste",
            Finalidade = Categoria.EFinalidade.Receita
        };

        var response = await _client.PostAsJsonAsync("/api/v1.0/categorias", dto);
        return (await response.Content.ReadFromJsonAsync<CategoriaDto>())!;
    }

    private async Task<CategoriaDto> CriarCategoriaDespesaAsync()
    {
        var dto = new CreateCategoriaDto
        {
            Descricao = "Despesa Teste",
            Finalidade = Categoria.EFinalidade.Despesa
        };

        var response = await _client.PostAsJsonAsync("/api/v1.0/categorias", dto);
        return (await response.Content.ReadFromJsonAsync<CategoriaDto>())!;
    }
}
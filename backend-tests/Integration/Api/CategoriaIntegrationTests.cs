using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Application.DTOs;
using MinhasFinancas.Infrastructure.Data;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace MinhasFinancas.Tests.Integration.Api;

[Trait("Category", "Integration")]
internal class CategoriaIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public CategoriaIntegrationTests(WebApplicationFactory<Program> factory)
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
                    options.UseInMemoryDatabase("TestDb_Categoria"));
            });
        });

        _client = _factory.CreateClient();
    }

    [Fact]
    public async Task CriarCategoria_ComFinalidadeValida_DeveRetornarCreated()
    {
        var dto = new CreateCategoriaDto
        {
            Descricao = "Salário Principal",
            Finalidade = Categoria.EFinalidade.Receita
        };

        var response = await _client.PostAsJsonAsync("/api/v1.0/categorias", dto);

        response.StatusCode.Should().Be(HttpStatusCode.Created);
        
        var categoriaCriada = await response.Content.ReadFromJsonAsync<CategoriaDto>();
        categoriaCriada.Should().NotBeNull();
        categoriaCriada!.Descricao.Should().Be("Salário Principal");
    }

    [Fact]
    public async Task CriarCategoria_DescricaoVazia_DeveRetornarBadRequest()
    {
        var dto = new CreateCategoriaDto
        {
            Descricao = "",
            Finalidade = Categoria.EFinalidade.Despesa
        };

        var response = await _client.PostAsJsonAsync("/api/v1.0/categorias", dto);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}

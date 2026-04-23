using FluentAssertions;
using MinhasFinancas.Domain.Entities;
using Xunit;

namespace MinhasFinancas.Tests.Unit.BusinessRules;

public class CategoriaBusinessRulesTests
{
    [Theory]
    [InlineData(Categoria.EFinalidade.Despesa, Transacao.ETipo.Receita, false)]
    [InlineData(Categoria.EFinalidade.Receita, Transacao.ETipo.Despesa, false)]
    [InlineData(Categoria.EFinalidade.Ambas, Transacao.ETipo.Receita, true)]
    [InlineData(Categoria.EFinalidade.Ambas, Transacao.ETipo.Despesa, true)]
    public void PermiteTipo_DeveRetornarResultadoConformeFinalidade(
        Categoria.EFinalidade finalidade,
        Transacao.ETipo tipo,
        bool esperado)
    {
        var categoria = new Categoria { Finalidade = finalidade };

        var resultado = categoria.PermiteTipo(tipo);

        resultado.Should().Be(esperado);
    }
}

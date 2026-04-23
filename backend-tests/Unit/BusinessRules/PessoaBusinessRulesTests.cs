using FluentAssertions;
using MinhasFinancas.Domain.Entities;
using Xunit;

namespace MinhasFinancas.Tests.Unit.BusinessRules;

public class PessoaBusinessRulesTests
{
    [Trait("Category", "Unit")]
    [Theory]
    [InlineData(17, false)]
    [InlineData(18, true)]
    [InlineData(25, true)]
    public void EhMaiorDeIdade_DeveRetornarCorretamente(int idade, bool esperado)
    {
        var dataNascimento = DateTime.Today.AddYears(-idade);
        var pessoa = new Pessoa { Nome = "Teste", DataNascimento = dataNascimento };

        var resultado = pessoa.EhMaiorDeIdade();

        resultado.Should().Be(esperado);
    }
}

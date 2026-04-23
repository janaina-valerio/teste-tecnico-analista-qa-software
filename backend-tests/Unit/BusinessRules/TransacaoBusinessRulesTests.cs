using FluentAssertions;
using MinhasFinancas.Domain.Entities;
using Xunit;

namespace MinhasFinancas.Tests.Unit.BusinessRules;

[Trait("Category", "Unit")]
public class TransacaoBusinessRulesTests
{
    [Fact]
    public void MenorDeIdade_NaoDevePermitirAssociarReceita()
    {
        var pessoaMenor = new Pessoa { Nome = "João Menor", DataNascimento = DateTime.Today.AddYears(-16) };
        var categoria = new Categoria { Finalidade = Categoria.EFinalidade.Receita };

        Action act = () => new Transacao
        {
            Descricao = "Salário Teste",
            Valor = 1500,
            Tipo = Transacao.ETipo.Receita,
            Categoria = categoria,
            Pessoa = pessoaMenor
        };

        act.Should().Throw<InvalidOperationException>();
    }
}

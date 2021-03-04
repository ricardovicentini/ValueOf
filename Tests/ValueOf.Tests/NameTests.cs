using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueOf.Demo;
using Xunit;

namespace ValueOf.Tests
{
    
    public class NameTests
    {
        [Fact(DisplayName = "Teste de validação do Primeiro Nome")]
        public void CriarNomeInvalidoPrimeiroNome()
        {
            var primeiroNomeNulo = new Name(null, null, "Teste");
            primeiroNomeNulo.IsValid.Should().BeFalse();
            primeiroNomeNulo.Errors.Should().HaveCount(1);
            primeiroNomeNulo.Errors[0].ErrorMessage.Should().Be("Primeiro nome deve ser informado.");

            var primeiroNomeVazio = new Name("", null, "Teste");
            primeiroNomeVazio.IsValid.Should().BeFalse();
            primeiroNomeVazio.Errors.Should().HaveCount(1);
            primeiroNomeVazio.Errors[0].ErrorMessage.Should().Be("Primeiro nome deve ser informado.");

            var primeiroNomeCurto = new Name("Ri", null, "Teste");
            primeiroNomeCurto.IsValid.Should().BeFalse();
            primeiroNomeCurto.Errors.Should().HaveCount(1);
            primeiroNomeCurto.Errors[0].ErrorMessage.Should().Be("Primeiro nome deve ter mais de 3 caracteres ou mais.");
        }

        [Fact(DisplayName = "Teste de validação do Sobrenome")]
        public void CriarNomeInvalidoSobreNome()
        {
            var sobrenomeNulo = new Name("Ricardo", null, null);
            sobrenomeNulo.IsValid.Should().BeFalse();
            sobrenomeNulo.Errors.Should().HaveCount(1);
            sobrenomeNulo.Errors[0].ErrorMessage.Should().Be("Sobrenome deve ser informado.");

            var sobrenomeVazio = new Name("Ricardo", null, "");
            sobrenomeVazio.IsValid.Should().BeFalse();
            sobrenomeVazio.Errors.Should().HaveCount(1);
            sobrenomeVazio.Errors[0].ErrorMessage.Should().Be("Sobrenome deve ser informado.");

            var sobrenomeCurto = new Name("Ricardo", null, "S");
            sobrenomeCurto.IsValid.Should().BeFalse();
            sobrenomeCurto.Errors.Should().HaveCount(1);
            sobrenomeCurto.Errors[0].ErrorMessage.Should().Be("Sobrenome deve ter mais de 2 caracteres ou mais.");

        }
    }
}

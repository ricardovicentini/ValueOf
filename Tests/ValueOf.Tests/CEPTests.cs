using FluentAssertions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueOf.Demo;
using Xunit;

namespace ValueOf.Tests
{
    public class CEPTests
    {
        [Fact(DisplayName = "Teste de exeções de validação de CEP")]
        public void CriarCEPInvalido()
        {
            new Action(() => new CEP(null))
                .Should().Throw<ValidationException>()
                .WithMessage("Validation failed: \n -- : CEP não pode ser nulo ou vazio");

            new Action(() => new CEP(""))
                .Should().Throw<ValidationException>()
                .WithMessage("Validation failed: \n -- : CEP não pode ser nulo ou vazio");

            new Action(() => new CEP("123456-414101"))
                .Should().Throw<ValidationException>()
                .WithMessage("Validation failed: \n -- : CEP deve possuir 8 digitos");

        }

        [Fact(DisplayName ="Teste CEP válido")]
        public void CirarCEPValido()
        {
            var cepValido = new CEP("03154-100");
            cepValido.IsValid.Should().BeTrue();
            cepValido.ToString().Equals("03154-100");

            cepValido = new CEP("03154100");
            cepValido.IsValid.Should().BeTrue();
            cepValido.ToString().Equals("03154-100");
        }

    }
}

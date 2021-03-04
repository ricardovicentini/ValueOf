using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueOf.Demo
{
    public class CEPValidator : AbstractValidator<string>
    {
        public CEPValidator()
        {
            RuleFor(c => c)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage("CEP não pode ser nulo ou vazio")
                .NotEmpty()
                .WithMessage("CEP não pode ser nulo ou vazio")
                .Length(8)
                .WithMessage("CEP deve possuir 8 digitos");
                
        }
    }
    public class CEP : ValueOfLib.VAlueOfWithValidation
        .ThrowOnValidation<string, CEP>
        //.WithMessage<string, CEP>
    {
        public CEP(string value) : base(value == null ? "" : value.RemoverNaoNumericos(), new CEPValidator())
        {
        }

        protected override bool Equals(CEP obj) => Value == obj.Value;

        public override string ToString()
        {
            return $"{Value.Substring(0,4)}-{Value.Substring(5)}";
        }
    }
}

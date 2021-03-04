using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueOf.Demo
{
    public class NameValidator : AbstractValidator<(string first, string middle, string last)>
    {
        
        public NameValidator()
        {
            RuleFor(n => n.first)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage("Primeiro nome deve ser informado.")
                .NotEmpty()
                .WithMessage("Primeiro nome deve ser informado.")
                .MinimumLength(3)
                .WithMessage("Primeiro nome deve ter mais de 3 caracteres ou mais.");


            RuleFor(n => n.last)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage("Sobrenome deve ser informado.")
                .NotEmpty()
                .WithMessage("Sobrenome deve ser informado.")
                .MinimumLength(2)
                .WithMessage("Sobrenome deve ter mais de 2 caracteres ou mais."); 

        }
    }
    public class Name : ValueOfLib.VAlueOfWithValidation
        .WithMessage<(string first, string middle, string last), Name>
    {
        public Name(string first, string middle, string last) : base((first, middle,last), new NameValidator())
        {
        }

        public void Deconstruct(out string first, out string middle, out string last)
        {
            first = this.Value.first;
            middle = this.Value.middle;
            last = this.Value.last;
        }

        protected override bool Equals(Name obj) => Value == obj.Value;

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Value.middle))
            {
                return $"{Value.first} {Value.last}";
            }
            else
            {
                return $"{Value.first} {Value.middle} {Value.last}";
            }

            
        }

    }
}

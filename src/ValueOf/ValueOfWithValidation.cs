using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;

namespace ValueOfLib
{
    public static class VAlueOfWithValidation
    {
        
        public abstract class WithMessage<TValue, TThis> : ValueOfBase<TValue, TThis> where TThis : WithMessage<TValue, TThis>
        {
            protected AbstractValidator<TValue> _validator;
            private ValidationResult _validationResult;

            protected WithMessage(TValue value, AbstractValidator<TValue> validator) : base(value)
            {
                _validator = validator;
                _validationResult = Validate(value);
            }

            protected virtual ValidationResult Validate(TValue value)
            {
                return _validator.Validate(value);
            }

            public bool IsValid 
            {
                get
                {
                    return _validationResult.IsValid;
                }
            }

            public IList<ValidationFailure> Errors
            {
                get
                {
                    return _validationResult.Errors;
                }
            }
        }

        public abstract class ThrowOnValidation<TValue, TThis> : WithMessage<TValue, TThis> where TThis : ThrowOnValidation<TValue, TThis>
        {
            protected ThrowOnValidation(TValue value, AbstractValidator<TValue> validator) : base(value, validator)
            {
                _validator = validator;
                ValidateAndThrow(value);
            }

            protected void ValidateAndThrow(TValue value)
            {
                _validator.ValidateAndThrow(value);
            }

            
        }
    }
}

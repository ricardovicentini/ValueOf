using System;

namespace ValueOfLib
{
    public abstract class ValueOf<TValue, TThis> : ValueOfBase<TValue, TThis>  where TThis : ValueOf<TValue, TThis>
    {
        protected ValueOf(TValue value)
            : base(value)
        {
            if (!Validate())
                throw new Exception();
        }

        protected abstract bool Validate();
    }
}
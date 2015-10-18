using System;
using MVCDS.Valid.Library.Rules;

namespace MVCDS.Valid.Library.Validators
{
    public interface IValidator<T>
    {
        void AddRule(Func<T, bool> callback);
        bool Validate(T value);
    }
}

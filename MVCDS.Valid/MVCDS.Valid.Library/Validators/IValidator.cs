using System;

namespace MVCDS.Valid.Library.Validators
{
    public interface IValidator<T>
    {
        string Name { get; }
        IValidator<T> Succeed(Func<T, bool> callback);
        bool Validate(T value);
    }
}

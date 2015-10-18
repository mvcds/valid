using System;

namespace MVCDS.Valid.Library.Validators
{
    public interface IValidator<T>
    {
        string Name { get; }
        IValidator<T> Succeed(Func<T, bool> callback);
        IValidator<T> Prepare(Func<T, T> callback);
        bool Validate(ref T value);
    }
}

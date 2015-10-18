using System;

namespace MVCDS.Valid.Library.Validators
{
    public interface IValidator<T>
    {
        string Name { get; }
        bool Validate(T value);
    }

    public interface IContableValidator<T> : IValidator<T>
    {
        int? Minimum { get; }
        int? Maximum { get; }
    }

    public interface IOptionalValidator<T> : IValidator<T>
    {
        bool Optional { get; }
    }
}

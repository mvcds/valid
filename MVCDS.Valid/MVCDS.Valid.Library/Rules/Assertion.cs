using System;

namespace MVCDS.Valid.Library.Rules
{
    internal class Assertion<T>: IStep
    {
        private Func<T, bool> callback;

        internal Assertion(Func<T, bool> callback)
        {
            this.callback = callback;
        }

        internal bool Validate(T value)
        {
            return callback(value);
        }
    }
}

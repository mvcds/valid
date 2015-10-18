using System;

namespace MVCDS.Valid.Library.Rules
{
    internal class Rule<T>
    {
        private Func<T, bool> callback;

        internal Rule(Func<T, bool> callback)
        {
            this.callback = callback;
        }

        internal bool Validate(T value)
        {
            return callback(value);
        }
    }
}

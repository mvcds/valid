using System;

namespace MVCDS.Valid.Library.Rules
{
    public class Rule<T>
    {
        private Func<T, bool> callback;

        internal Rule(Func<T, bool> callback)
        {
            this.callback = callback;
        }

        internal bool Validate(T value)
        {
            try
            {
                return callback(value);
            }
            catch
            {
                return false;
            }
        }
    }
}

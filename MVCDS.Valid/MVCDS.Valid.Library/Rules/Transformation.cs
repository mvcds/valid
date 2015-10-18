using System;

namespace MVCDS.Valid.Library.Rules
{
    internal class Transformation<T>: IStep
    {
        private Func<T, T> callback;

        internal Transformation(Func<T, T> callback)
        {
            this.callback = callback;
        }

        internal T Perform(T value)
        {
            return callback(value);
        }
    }
}
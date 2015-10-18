using System;
using System.Collections.Generic;
using MVCDS.Valid.Library.Rules;
using System.Linq;

namespace MVCDS.Valid.Library.Validators
{
    public class Validator<T> : IValidator<T>
    {
        List<Rule<T>> _rules = new List<Rule<T>>();

        public void AddRule(Func<T, bool> callback)
        {
            Rule<T> rule = new Rule<T>(callback);
            _rules.Add(rule);
        }

        public bool Validate(T value)
        {
            return _rules.All(p => p.Validate(value));
        }
    }
}

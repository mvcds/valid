using System;
using System.Collections.Generic;
using MVCDS.Valid.Library.Rules;
using System.Linq;

namespace MVCDS.Valid.Library.Validators
{
    public class Validator<T> : IValidator<T>
    {
        List<Rule<T>> rules = new List<Rule<T>>();

        public Validator(string name)
        {
            if (name == null)
                throw new ArgumentNullException();

            name = name.Trim();
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException();

            _name = name;
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
        }

        public IValidator<T> Succeed(Func<T, bool> callback)
        {
            Rule<T> rule = new Rule<T>(callback);
            rules.Add(rule);
            return this;
        }

        public bool Validate(T value)
        {
            return rules.All(p => p.Validate(value));
        }
    }
}

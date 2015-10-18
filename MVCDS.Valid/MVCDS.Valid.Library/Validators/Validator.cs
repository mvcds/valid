using System;
using System.Collections.Generic;
using MVCDS.Valid.Library.Rules;
using System.Linq;

namespace MVCDS.Valid.Library.Validators
{
    public class Validator<T> : IValidator<T>
    {
        List<IStep> steps = new List<IStep>();

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
            Assertion<T> assertion = new Assertion<T>(callback);
            steps.Add(assertion);
            return this;
        }

        public IValidator<T> Prepare(Func<T, T> callback)
        {
            Transformation<T> assertion = new Transformation<T>(callback);
            steps.Add(assertion);
            return this;
        }

        public bool Validate(ref T value)
        {
            foreach(IStep step in steps)
            {
                Assertion<T> rule = step as Assertion<T>;
                if (rule == null)
                {
                    Transformation<T> transform = step as Transformation<T>;
                    value = transform.Perform(value);
                }
                else if (!rule.Validate(value))
                    return false;
            }
            return true;
        }
    }
}

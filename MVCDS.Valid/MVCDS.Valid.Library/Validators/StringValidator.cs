using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDS.Valid.Library.Validators
{
    public class StringValidator : IContableValidator<string>, IOptionalValidator<string>
    {
        public StringValidator(string name, int? min = null, int? max = null, bool optional = false)
        {
            if (name == null)
                throw new ArgumentNullException("Validator's name is null");

            name = name.Trim();
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Validator's name is e empty");

            _name = name;
            Minimum = min;
            Maximum = max;
            Optional = optional;
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
        }

        public int? Minimum { get; private set; }
        public int? Maximum { get; private set; }
        public bool Optional { get; private set; }

        public bool Validate(string value)
        {
            if (value == null)
                return Optional;

            if (Minimum.HasValue && value.Length < Minimum)
                return false;

            if (Maximum.HasValue && value.Length > Maximum)
                return false;

            return true;
        }
    }
}

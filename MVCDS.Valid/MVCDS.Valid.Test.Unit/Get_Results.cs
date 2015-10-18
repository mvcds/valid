using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCDS.Valid.Library.Validators;

namespace MVCDS.Valid.Test.Unit
{
    [TestClass]
    public class Get_Results
    {
        [TestMethod]
        public void Compose_A_Rule_Using_Functions()
        {
            Validator<string> validator = new Validator<string>("password's length")
                 .Fail(s => s == null)
                 .Prepare(s => s.Trim())
                 .Fail(s => string.IsNullOrWhiteSpace(s))
                 .Succeed(s => s.Length >= 3 && s.Length <= 16);

            Assert.IsFalse(validator.Validate(null));
            Assert.IsFalse(validator.Validate(new string('a', 1)));
            Assert.IsTrue(validator.Validate(new string('a', 5)));
            Assert.IsFalse(validator.Validate(new string('a', 25)));
        }

        [TestMethod]
        public void Validate_As_String()
        {
            StringValidator validator = new StringValidator("password's length", 3, 16, false);

            Assert.IsFalse(validator.Validate(null));
            Assert.IsFalse(validator.Validate(new string('a', 1)));
            Assert.IsTrue(validator.Validate(new string('a', 5)));
            Assert.IsFalse(validator.Validate(new string('a', 25)));
        }
    }
}


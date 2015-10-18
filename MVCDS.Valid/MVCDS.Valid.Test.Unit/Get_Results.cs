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
           IValidator<string> validator = new Validator<string>("password's length")
                .Succeed(s => s != null)
                .Prepare(s => s.Trim())
                .Succeed(s => !string.IsNullOrWhiteSpace(s))
                .Succeed(s => s.Length >= 3 && s.Length <= 16);

            string _null = null,
                _under = new string('a', 1) + "  ",
                _in = new string('a', 5),
                _over = new string('a', 25);

            Assert.AreEqual(validator.Validate(ref _null), false);
            Assert.AreEqual(validator.Validate(ref _under), false);
            Assert.AreEqual(validator.Validate(ref _in), true);
            Assert.AreEqual(validator.Validate(ref _over), false);
        }
    }
}


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
           IValidator<string> validator = new Validator<string>("Password's length")
                .Succeed(s => s != null)
                .Succeed(s => !string.IsNullOrWhiteSpace(s))
                .Succeed(s => s.Length >= 3 && s.Length <= 16);
            
            Assert.AreEqual(validator.Validate(null), false);
            Assert.AreEqual(validator.Validate(new string('a', 1)), false);
            Assert.AreEqual(validator.Validate(new string('a', 5)), true);
            Assert.AreEqual(validator.Validate(new string('a', 25)), false);
        }
    }
}


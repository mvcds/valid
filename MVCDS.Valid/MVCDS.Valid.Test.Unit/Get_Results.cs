using Microsoft.VisualStudio.TestTools.UnitTesting;
using lib = MVCDS.Valid.Library;

namespace MVCDS.Valid.Test.Unit
{
    [TestClass]
    public class Get_Results
    {
        [TestMethod]
        public void Use_A_Function()
        {
            lib.Validators.Validator<string> validator = new lib.Validators.Validator<string>();
            validator.AddRule(s => s.Length >= 3 && s.Length <= 16);

            Assert.AreEqual(validator.Validate(null), false);
            Assert.AreEqual(validator.Validate(new string('a', 1)), false);
            Assert.AreEqual(validator.Validate(new string('a', 5)), true);
            Assert.AreEqual(validator.Validate(new string('a', 25)), false);
        }
    }
}


using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SheetPrinter.Core.Tests
{
    [TestClass()]
    public class UnitConvertTests
    {
        [TestMethod()]
        public void CmToPrintTest()
        {
            Assert.AreEqual(UnitConvert.CmToPrint(2.54f), 100f);
            Assert.AreEqual(UnitConvert.CmToPrint_int(2.54f), 100);
        }

        [TestMethod()]
        public void CmToPxTest()
        {
            Assert.AreEqual(UnitConvert.CmToPx(2.54f, 72f), 72f);
            Assert.AreEqual(UnitConvert.CmToPx_int(2.54f, 72f), 72);
        }

        [TestMethod()]
        public void PxToCmTest()
        {
            Assert.AreEqual(UnitConvert.PxToCm(72f, 72f), 2.54f);
        }
    }
}
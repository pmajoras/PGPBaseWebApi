using Microsoft.VisualStudio.TestTools.UnitTesting;
using PGP.Infrastructure.Framework.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGP.Infrastructure.Framework.Tests.Enumerators
{
    [TestClass]
    public class EnumExtensionsTest
    {
        #region Initialize

        [TestInitialize]
        public void Initialize()
        {

        }

        #endregion

        #region Test Methods

        /// <summary>
        /// Tests the method ToInt with parameter Test1 and the expected result is One
        /// </summary>
        [TestMethod]
        public void ToInt_Test1_One()
        {
            Assert.AreEqual(1, EnumForTest.Test1.ToInt());
        }

        /// <summary>
        /// Tests the method ToInt with parameter Test2 and the expected result is Two
        /// </summary>
        [TestMethod]
        public void ToInt_Test2_Two()
        {
            Assert.AreEqual(2, EnumForTest.Test2.ToInt());
        }

        /// <summary>
        /// Tests the method ToInt with parameter TestNoValue3 and the expected result is Three
        /// </summary>
        [TestMethod]
        public void ToInt_TestNoValue3_Three()
        {
            Assert.AreEqual(3, EnumForTest.TestNoValue3.ToInt());
        }

        #endregion
    }
}

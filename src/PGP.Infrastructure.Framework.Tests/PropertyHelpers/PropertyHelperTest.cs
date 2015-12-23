using Microsoft.VisualStudio.TestTools.UnitTesting;
using PGP.Infrastructure.Framework.PropertyHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PGP.Infrastructure.Framework.Tests.PropertyHelpers
{
    [TestClass]
    public class PropertyHelperTest
    {
        #region Initialize

        [TestInitialize]
        public void Initialize()
        {

        }

        #endregion

        #region Test Methods

        /// <summary>
        /// Tests the method GetPropertyName with parameter DataPropertyExpression and the expected result is Success
        /// </summary>
        [TestMethod]
        public void GetPropertyName_DataPropertyExpression_Success()
        {
            var dataPropertyName = PropertyHelper.GetPropertyName<FormatException>(x => x.Data);

            Assert.AreEqual("Data", dataPropertyName);
        }

        /// <summary>
        /// Tests the method GetPropertyName with parameter ChainedExpression and the expected result is Success
        /// </summary>
        [TestMethod]
        public void GetPropertyName_ChainedExpression_Success()
        {
            var messagePropertyName = PropertyHelper.GetPropertyName<FormatException>(x => x.InnerException.Message);

            Assert.AreEqual("InnerException.Message", messagePropertyName);
        }

        /// <summary>
        /// Tests the method GetPropertyName with parameter ChainedExpression and the expected result is ArgumentNullException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetPropertyName_Null_ArgumentNullException()
        {
            var messagePropertyName = PropertyHelper.GetPropertyName<FormatException>(null);

            Assert.Fail();
        }

        /// <summary>
        /// Tests the method GetPropertyName with parameter ChainedExpression and the expected result is ArgumentException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetPropertyName_InvalidExpression_ArgumentException()
        {
            Expression<Func<FormatException, object>> invalidExpression = x => x.GetBaseException();

            var messagePropertyName = PropertyHelper.GetPropertyName(invalidExpression);

            Assert.Fail();
        }

        #endregion
    }
}

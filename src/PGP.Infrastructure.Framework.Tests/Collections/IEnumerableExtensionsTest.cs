using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PGP.Infrastructure.Framework.Collections;

namespace PGP.Infrastructure.Framework.Tests.Collections
{
    [TestClass]
    public class IEnumerableExtensionsTest
    {
        #region Initialize

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
        }

        #endregion Initialize

        #region Tests Methods

        /// <summary>
        /// Tests the method DistinctByProperty with parameter NormalList and the expected result is Success
        /// </summary>
        [TestMethod]
        public void DistinctByProperty_NormalList_Success()
        {
            var list = new List<Exception>();
            list.Add(new Exception("Teste1"));
            list.Add(new Exception("Teste2"));
            list.Add(new Exception("Teste3"));

            var distinctList = list.DistinctByProperty(x => x.Message);

            foreach (var item in distinctList)
            {
                if (distinctList.Any(x => x != item && x.Message == item.Message))
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// Tests the method DistinctByProperty with parameter ListWithDuplicate and the expected result is Success
        /// </summary>
        [TestMethod]
        public void DistinctByProperty_ListWithDuplicate_Success()
        {
            var list = new List<Exception>();
            list.Add(new Exception("Teste1"));
            list.Add(new Exception("Teste2"));
            list.Add(new Exception("Teste2"));

            var distinctList = list.DistinctByProperty(x => x.Message);

            foreach (var item in distinctList)
            {
                if (distinctList.Any(x => x != item && x.Message == item.Message))
                {
                    Assert.Fail();
                }
            }

            Assert.AreEqual(2, distinctList.Count());
        }

        /// <summary>
        /// Tests the method DistinctByProperty with parameter Null and the expected result is ArgumentNullException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DistinctByProperty_Null_ArgumentNullException()
        {
            var list = new List<Exception>();
            list.Add(new Exception("Teste1"));
            list.Add(new Exception("Teste2"));
            list.Add(new Exception("Teste2"));

            var distinctList = list.DistinctByProperty(null);

            Assert.Fail();
        }

        #endregion Tests Methods
    }
}
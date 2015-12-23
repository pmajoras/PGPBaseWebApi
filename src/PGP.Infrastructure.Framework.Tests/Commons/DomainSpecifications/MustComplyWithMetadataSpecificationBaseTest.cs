using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PGP.Infrastructure.Framework.Commons.DomainSpecifications;
using System.Linq;
using System.Collections.Generic;
using PGP.Infrastructure.Framework.Specifications.Errors;
using System.ComponentModel.DataAnnotations;

namespace PGP.Infrastructure.Framework.Tests.Commons.DomainSpecifications
{
    /// <summary>
    /// Test class for MustComplyWithMetadataSpecificationBase
    /// </summary>
    [TestClass]
    public class MustComplyWithMetadataSpecificationBaseTest
    {
        #region Initialization

        /// <summary>
        /// Initialize the Tests for the class MustComplyWithMetadataSpecificationBase
        /// </summary>
        [TestInitialize]
        public void InitializeTests()
        {

        }

        #endregion

        #region Tests Constructors

        /// <summary>
        /// Tests the method IsSatisfiedBy with parameter ConstructorEmpty and the expected result is IsNotSatisfied
        /// </summary>
        [TestMethod]
        public void IsSatisfiedBy_ConstructorEmpty_Success()
        {
            var entity = new MustComplyEntity();
            var specification = new MustComplyWithMetadataSpecificationBase<MustComplyEntity>();

            Assert.IsFalse(specification.IsSatisfiedBy(entity));
            Assert.AreEqual(specification.SpecificationResult.GetErrors().Count, 1);
        }

        /// <summary>
        /// Tests the method IsStisfiedby with parameter ConstrctorEmpty and the expected result is Succes
        /// </summary>
        [TestMethod]
        public void IsStisfiedby_ConstrctorEmpty_Succes()
        {
            var entity = new MustComplyEntity();
            var specification = new MustComplyWithMetadataSpecificationBase<MustComplyEntity>();
            entity.Name = "dwqqdw";
            entity.NameMinLength = "kdqop";

            Assert.IsTrue(specification.IsSatisfiedBy(entity));
        }

        /// <summary>
        /// Tests the method IsSatisfiedBy with parameter CustomErrorCodeConstructors and the expected result is CustomErrorCodeOnError
        /// </summary>
        [TestMethod]
        public void IsSatisfiedBy_CustomErrorCodeConstructors_CustomErrorCodeOnError()
        {
            var entity = new MustComplyEntity();
            var specification = new MustComplyWithMetadataSpecificationBase<MustComplyEntity>(5, 6, 7);

            Assert.IsFalse(specification.IsSatisfiedBy(entity));
            Assert.IsTrue(specification.SpecificationResult.GetErrors().Any(x => x.ErrorCode == 5));
        }

        /// <summary>
        /// Tests the method IsSatisfiedBy with parameter CustomErrors and the expected result is CustomErrorWithCustomCodeAndMsg
        /// </summary>
        [TestMethod]
        public void IsSatisfiedBy_CustomErrors_CustomErrorWithCustomCodeAndMsg()
        {
            var myErrors = new Dictionary<Type, DomainSpecificationError>();
            string customMessage = "Minha Mensagem";
            int customCode = 10;

            myErrors.Add(typeof(RequiredAttribute), new DomainSpecificationError(customCode, customMessage));

            var specification = new MustComplyWithMetadataSpecificationBase<MustComplyEntity>(myErrors);

            Assert.IsFalse(specification.IsSatisfiedBy(new MustComplyEntity()));
            Assert.IsTrue(specification.SpecificationResult.GetErrors().Any(x => x.ErrorCode == customCode));
            Assert.IsTrue(specification.SpecificationResult.GetErrors().Any(x => x.NotSatisfiedReason == customMessage));
        }

        #endregion
    }
}

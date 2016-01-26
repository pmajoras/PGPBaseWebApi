using PGP.Infrastructure.Framework.DomainContexts.EF.EFContexts;
using PGP.Infrastructure.Repositories.EF.Mappings.Books;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGP.Infrastructure.Repositories.EF
{
    /// <summary>
    /// 
    /// </summary>
    public class EFBaseContext : EFContext
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EFBaseContext"/> class.
        /// </summary>
        public EFBaseContext()
            : base("PGPDatabase")
        {

        }

        #endregion

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuidler, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.
        /// </remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException("modelBuilder");
            }

            modelBuilder.Configurations.AddFromAssembly(typeof(BookMap).Assembly);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}

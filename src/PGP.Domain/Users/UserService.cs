using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KissSpecifications;
using PGP.Domain.Users.Specs;
using PGP.Infrastructure.Framework.Commons.DomainSpecifications;
using PGP.Infrastructure.Framework.Cryptography;
using PGP.Infrastructure.Framework.Repositories;
using PGP.Infrastructure.Framework.Specifications.Errors;
using PGP.Infrastructure.Framework.Strings;

namespace PGP.Domain.Users
{
    /// <summary>
    /// 
    /// </summary>
    public class UserService : DomainServiceBase<User, IUserRepository>, IUserService
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="userRepository">The user repository.</param>
        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository)
            : base(unitOfWork, userRepository)
        {

        }

        #endregion

        #region Interface Methods

        /// <summary>
        /// Gets the valid user for login.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public User GetValidUserForLogin(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            User validUser = null;

            var user = m_repository.FindAll(x => x.Username == username)
                .FirstOrDefault();

            if (user != null)
            {
                if (PasswordHasher.VerifyPassword(password, user.Salt, user.Password))
                {
                    validUser = user;
                }
            }

            return validUser;
        }

        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="fullName">The full name.</param>
        /// <param name="nickName">Name of the nick.</param>
        public User RegisterUser(string username, string password, string fullName, string nickName)
        {
            User user = new User()
            {
                FullName = fullName,
                NickName = nickName,
                Username = username,
                Password = password,
            };

            SaveEntity(user);

            return user;
        }

        #endregion

        /// <summary>
        /// Saves the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public override void SaveEntity(User entity)
        {
            if (entity.IsNew || string.IsNullOrEmpty(entity.Password) || !entity.Password.IsBase64())
            {
                AssertSpecification(entity, new UserHasValidPasswordSpec());
                entity.Salt = PasswordHasher.GenerateSalt();
                entity.Password = PasswordHasher.ComputeHash(entity.Password, entity.Salt);
            }

            base.SaveEntity(entity);
        }

        /// <summary>
        /// Gets the save specifications.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        protected override ISpecification<User>[] GetSaveSpecifications(User entity)
        {
            var specifications = base.GetSaveSpecifications(entity).ToList();
            specifications.AddRange(new ISpecification<User>[]
            {
                new UserIsNotUniqueSpec(FindAll(x=> x.Id != entity.Id))
            });

            return specifications.ToArray();
        }
    }
}

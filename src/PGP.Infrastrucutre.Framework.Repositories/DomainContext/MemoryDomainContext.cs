using System;
using System.Collections.Generic;
using System.Linq;
using HelperSharp;

namespace PGP.Infrastructure.Framework.Repositories
{
    /// <summary>
    /// Class that represents a context that can be used for unit testing
    /// </summary>
    public class MemoryDomainContext : IDomainContext
    {
        #region Private Properties

        /// <summary>
        /// The initial id that will be used to generate a new entity
        /// </summary>
        private int m_idGenerator = 1;

        /// <summary>
        /// The m_memory database
        /// </summary>
        private Dictionary<Type, List<IEntity>> m_memoryDatabase = new Dictionary<Type, List<IEntity>>();

        /// <summary>
        /// The m_memory entities to change
        /// </summary>
        private Dictionary<Type, List<IEntity>> m_memoryEntitiesToChange = new Dictionary<Type, List<IEntity>>();

        /// <summary>
        /// The m_memory entities to add
        /// </summary>
        private Dictionary<Type, List<IEntity>> m_memoryEntitiesToAdd = new Dictionary<Type, List<IEntity>>();

        /// <summary>
        /// The m_memory entities to remove
        /// </summary>
        private Dictionary<Type, List<IEntity>> m_memoryEntitiesToRemove = new Dictionary<Type, List<IEntity>>();

        /// <summary>
        /// The m_memory attached entities
        /// </summary>
        private Dictionary<Type, List<IEntity>> m_memoryAttachedEntities = new Dictionary<Type, List<IEntity>>();

        /// <summary>
        /// The m_repositories
        /// </summary>
        private Dictionary<Type, IRepository<IEntity>> m_repositories = new Dictionary<Type, IRepository<IEntity>>();

        /// <summary>
        /// The current transaction
        /// </summary>
        private object m_currentTransaction = null;

        /// <summary>
        /// The variable that indicates that the dispose method has been called
        /// </summary>
        private bool m_disposed = false;

        #endregion Private Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryDomainContext"/> class.
        /// </summary>
        public MemoryDomainContext()
        {
        }

        #endregion Constructors

        #region Interface Methods

        /// <summary>
        /// Registers the entity as a new entity in the context.
        /// </summary>
        /// <typeparam name="TRepository"></typeparam>
        /// <param name="repository"></param>
        /// <exception cref="System.ArgumentException">The MemoryDomainContext already contains an repository with the type  + repositoryType.Name + .</exception>
        public void RegisterRepository<TRepository>(IRepository<TRepository> repository) where TRepository : class, IEntity
        {
            ExceptionHelper.ThrowIfNull("repository", repository);

            var repositoryType = typeof(TRepository);

            if (m_repositories.Any(x => x.Key == repositoryType))
            {
                throw new ArgumentException("The MemoryDomainContext already contains an repository with the type " + repositoryType.Name + ".");
            }

            m_repositories.Add(repositoryType, repository as IRepository<IEntity>);
        }

        /// <summary>
        /// Gets the entity by identifier.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public TEntity GetById<TEntity>(object id)
            where TEntity : class, IEntity
        {
            long intId = 0;
            if (id is long)
            {
                intId = (long)id;
            }

            var query = GetSpecificListFromDictionary<TEntity>(m_memoryDatabase);

            return (TEntity)query.Where(x => x.Id == intId).FirstOrDefault();
        }

        /// <summary>
        /// Creates a query to be filtered.
        /// </summary>
        /// <typeparam name="TEntity">Type of the entity.</typeparam>
        /// <returns></returns>
        public IQueryable<TEntity> CreateQuery<TEntity>() where TEntity : class, IEntity
        {
            var query = GetSpecificListFromDictionary<TEntity>(m_memoryDatabase);
            var returnQuery = new List<TEntity>();

            foreach (var entity in query)
            {
                returnQuery.Add((TEntity)ObjectHelper.CreateShallowCopy(entity));
            }

            return returnQuery.AsQueryable();
        }

        /// <summary>
        /// Registers the entity as a changed entity in the context.
        /// </summary>
        /// <typeparam name="TEntity">Type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        public void RegisterChanged<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            ExceptionHelper.ThrowIfNull("entity", entity);
            var listToRegister = GetSpecificListFromDictionary<TEntity>(m_memoryEntitiesToChange);

            if (listToRegister.Any(x => x.Id == entity.Id))
            {
                var entityToUpdate = listToRegister.First(x => x.Id == entity.Id);
                listToRegister[listToRegister.IndexOf(entityToUpdate)] = entity;
            }
            else
            {
                listToRegister.Add(entity);
            }
        }

        /// <summary>
        /// Registers entity as a deleted entity in the context.
        /// </summary>
        /// <typeparam name="TEntity">Type of the entity.</typeparam>
        /// <param name="entity">The entity to be deleted.</param>
        public void RegisterDeleted<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            ExceptionHelper.ThrowIfNull("entity", entity);
            var listToRegister = GetSpecificListFromDictionary<TEntity>(m_memoryEntitiesToRemove);

            if (!listToRegister.Contains(entity))
            {
                listToRegister.Add(entity);
            }
        }

        /// <summary>
        /// Registers the entity as a new entity in the context.
        /// </summary>
        /// <typeparam name="TEntity">Type of the entity.</typeparam>
        /// <param name="entity">The entity to be registered.</param>
        public void RegisterNew<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            ExceptionHelper.ThrowIfNull("entity", entity);
            var listToRegister = GetSpecificListFromDictionary<TEntity>(m_memoryEntitiesToAdd);

            if (!listToRegister.Contains(entity))
            {
                listToRegister.Add(entity);
            }
        }

        public void Attach<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            ExceptionHelper.ThrowIfNull("entity", entity);
            var listToRegister = GetSpecificListFromDictionary<TEntity>(m_memoryAttachedEntities);

            if (!listToRegister.Contains(entity))
            {
                listToRegister.Add(entity);
            }
        }

        /// <summary>
        /// Begin a transaction
        /// </summary>
        public void BeginTransaction()
        {
            if (m_currentTransaction == null)
            {
                m_currentTransaction = new object();
            }
        }

        /// <summary>
        /// Rollback the oppened transaction
        /// </summary>
        /// <exception cref="System.InvalidOperationException">There are not pending transactions to roolback.</exception>
        public void RoolbackTransaction()
        {
            if (m_currentTransaction == null)
            {
                throw new InvalidOperationException("There are not pending transactions to roolback.");
            }
            m_currentTransaction = null;
            ClearContext();
        }

        /// <summary>
        /// Commit the oppened transaction
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        /// A transaction must be started for a commit be evaluated.
        /// or
        /// There are entities registered to be changed that does not have a valid Id.
        /// or
        /// There are entities registered to be removed that does not have a valid Id.
        /// </exception>
        public void CommitTransaction()
        {
            if (m_currentTransaction == null)
            {
                throw new InvalidOperationException("A transaction must be started for a commit be evaluated.");
            }

            foreach (var entitiesToChange in m_memoryEntitiesToChange)
            {
                if (m_repositories.Any(x => x.Key == entitiesToChange.Key))
                {
                    var repository = m_repositories.First(x => x.Key == entitiesToChange.Key);
                    foreach (var entity in entitiesToChange.Value)
                    {
                        repository.Value.BeforePersistUpdatedItem(entity);
                    }
                }

                var dataBaseEntities = GetSpecificListFromDictionary(entitiesToChange.Key, m_memoryDatabase);
                if (entitiesToChange.Value.Any(x => dataBaseEntities.FirstOrDefault(y => y.Id == x.Id) == null))
                {
                    throw new InvalidOperationException("There are entities registered to be changed that does not have a valid Id.");
                }

                foreach (var entity in entitiesToChange.Value)
                {
                    var dataBaseEntity = dataBaseEntities.FirstOrDefault(x => x.Id == entity.Id);
                    dataBaseEntities[dataBaseEntities.IndexOf(dataBaseEntity)] = entity;
                }
            }

            foreach (var entitiesToRemove in m_memoryEntitiesToRemove)
            {
                if (m_repositories.Any(x => x.Key == entitiesToRemove.Key))
                {
                    var repository = m_repositories.First(x => x.Key == entitiesToRemove.Key);
                    foreach (var entity in entitiesToRemove.Value)
                    {
                        repository.Value.BeforeDeleteItem(entity);
                    }
                }

                var dataBaseEntities = GetSpecificListFromDictionary(entitiesToRemove.Key, m_memoryDatabase);
                if (entitiesToRemove.Value.Any(x => dataBaseEntities.FirstOrDefault(y => y.Id == x.Id) == null))
                {
                    throw new InvalidOperationException("There are entities registered to be removed that does not have a valid Id.");
                }

                foreach (var entity in entitiesToRemove.Value)
                {
                    var dataBaseEntity = dataBaseEntities.FirstOrDefault(x => x.Id == entity.Id);
                    dataBaseEntities.Remove(dataBaseEntity);
                }
            }

            foreach (var entitiesToAdd in m_memoryEntitiesToAdd)
            {
                if (m_repositories.Any(x => x.Key == entitiesToAdd.Key))
                {
                    var repository = m_repositories.First(x => x.Key == entitiesToAdd.Key);
                    foreach (var entity in entitiesToAdd.Value)
                    {
                        repository.Value.BeforePersistNewItem(entity);
                    }
                }

                var dataBaseEntities = GetSpecificListFromDictionary(entitiesToAdd.Key, m_memoryDatabase);

                foreach (var entity in entitiesToAdd.Value)
                {
                    entity.Id = m_idGenerator;
                    m_idGenerator++;
                    dataBaseEntities.Add(entity);
                }
            }

            ClearContext();
        }

        /// <summary>
        /// Clear the context, removes all entities that are attached in the context.
        /// </summary>
        public void ClearContext()
        {
            m_currentTransaction = null;
            m_memoryAttachedEntities.Clear();
            m_memoryEntitiesToAdd.Clear();
            m_memoryEntitiesToChange.Clear();
            m_memoryEntitiesToRemove.Clear();
        }

        /// <summary>
        /// Save the context changes and commit, in case of error this method is supposed to call the <see cref="RoolbackTransaction" /> method.
        /// </summary>
        public void SaveContextChanges()
        {
            try
            {
                BeginTransaction();
                CommitTransaction();
            }
            catch (Exception)
            {
                RoolbackTransaction();
                throw;
            }
        }

        #endregion Interface Methods

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether this instance has pending transaction.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has pending transaction; otherwise, <c>false</c>.
        /// </value>
        public bool HasPendingTransaction { get { return m_currentTransaction != null; } }

        #endregion Public Properties

        #region Dispose

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    ClearContext();
                    m_repositories.Clear();
                }

                // Dispose unmanaged managed resources.
                m_disposed = true;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion Dispose

        #region Helpers

        /// <summary>
        /// Inserts the not contained elements to list.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="listToChange">The list to change.</param>
        /// <param name="listToCheck">The list to check.</param>
        private void InsertNotContainedElementsToList<TEntity>(List<TEntity> listToChange, IEnumerable<TEntity> listToCheck) where TEntity : IEntity
        {
            ExceptionHelper.ThrowIfNull("listToChange", listToChange);
            ExceptionHelper.ThrowIfNull("listToCheck", listToCheck);

            listToChange.AddRange(listToCheck.Where(x => !listToChange.Any(y => y.Id == x.Id)));
        }

        /// <summary>
        /// Removes the contained elements from list.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="listToRemove">The list to remove.</param>
        /// <param name="listToCheck">The list to check.</param>
        private void RemoveContainedElementsFromList<TEntity>(List<TEntity> listToRemove, IEnumerable<TEntity> listToCheck) where TEntity : IEntity
        {
            ExceptionHelper.ThrowIfNull("listToRemove", listToRemove);
            ExceptionHelper.ThrowIfNull("listToCheck", listToCheck);

            foreach (var item in listToRemove.ToList())
            {
                if (listToCheck.Any(x => x.Id == item.Id))
                {
                    listToRemove.Remove(item);
                }
            }
        }

        /// <summary>
        /// Gets the specific list from dictionary.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <returns></returns>
        private List<IEntity> GetSpecificListFromDictionary<TEntity>(Dictionary<Type, List<IEntity>> dictionary)
            where TEntity : IEntity
        {
            ExceptionHelper.ThrowIfNull("dictionary", dictionary);

            return GetSpecificListFromDictionary(typeof(TEntity), dictionary);
        }

        /// <summary>
        /// Gets the specific list from dictionary.
        /// </summary>
        /// <param name="listType">Type of the list.</param>
        /// <param name="dictionary">The dictionary.</param>
        /// <returns></returns>
        private List<IEntity> GetSpecificListFromDictionary(Type listType, Dictionary<Type, List<IEntity>> dictionary)
        {
            ExceptionHelper.ThrowIfNull("dictionary", dictionary);

            if (!ContainsSpecificType(listType, dictionary))
            {
                dictionary.Add(listType, new List<IEntity>());
            }

            return dictionary[listType];
        }

        /// <summary>
        /// Determines whether [contains specific type] [the specified dictionary].
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <returns></returns>
        private bool ContainsSpecificType<TEntity>(Dictionary<Type, List<IEntity>> dictionary) where TEntity : IEntity
        {
            ExceptionHelper.ThrowIfNull("dictionary", dictionary);

            return ContainsSpecificType(typeof(TEntity), dictionary);
        }

        /// <summary>
        /// Determines whether [contains specific type] [the specified list type].
        /// </summary>
        /// <param name="listType">Type of the list.</param>
        /// <param name="dictionary">The dictionary.</param>
        /// <returns></returns>
        private bool ContainsSpecificType(Type listType, Dictionary<Type, List<IEntity>> dictionary)
        {
            ExceptionHelper.ThrowIfNull("dictionary", dictionary);

            return dictionary.ContainsKey(listType);
        }

        #endregion Helpers
    }
}
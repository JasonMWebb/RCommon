﻿namespace RCommon.ObjectAccess.EFCore
{
    using Microsoft.EntityFrameworkCore;
    using RCommon;
    using RCommon.DataServices.Transactions;
    using RCommon.Domain.Repositories;
    using RCommon.Expressions;
    using RCommon.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Threading.Tasks;

    /// <summary>
    /// A concrete implementation of <see cref="RepositoryBase{TEntity}"/> and <see cref="IRepository{TEntity}"/> for Entity Framework Core version 3.x. This class
    /// currently exposes much of the functionality of EF with the exception of change tracking and peristance models. We expose IQueryable to layers up stream
    /// so that complex joins can be utilized and then managed at the domain level. This implementation makes special considerations for managing the lifetime of the
    /// <see cref="DbContext"/> specifically when it applies to the <see cref="UnitOfWorkScope"/>. 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class EFCoreRepository<TEntity, TDataStore> : FullFeaturedRepositoryBase<TEntity, TDataStore> 
        where TEntity : class
        where TDataStore : DbContext
    {
        private readonly List<string> _includes;
        //private string _contextName;
        private ObjectSourceLifetimeManager<DbContext> _objectContextLifetimeManager;
        private DbContext _objectContext;
        private DbSet<TEntity> _objectSet;
        private IQueryable<TEntity> _repositoryQuery;
        private bool _tracking;
        private readonly Dictionary<Type, object> _objectSets;
        private Type _type;




        public EFCoreRepository(ObjectSourceLifetimeManager<DbContext> objectSourceLifetimeManager)
        {
            this._includes = new List<string>();
            this._objectContext = null;
            this._objectSet = null;
            this._repositoryQuery = null;
            this._tracking = true;
            this._objectSets = new Dictionary<Type, object>();
            this._objectContextLifetimeManager = objectSourceLifetimeManager;
        }

        public EFCoreRepository(string contextName, ObjectSourceLifetimeManager<DbContext> objectSourceLifetimeManager)
        {
            this._includes = new List<string>();
            this._objectContext = null;
            this._objectSet = null;
            this._repositoryQuery = null;
            this._tracking = true;
            this._objectSets = new Dictionary<Type, object>();
            //this._contextName = contextName;
            this._objectContextLifetimeManager = objectSourceLifetimeManager;
        }

        public override TEntity Add(TEntity entity)
        {
            var updatedEntity = this.ObjectSet.Add(entity).Entity;
            this.Save();
            return updatedEntity;
        }


        protected override void ApplyFetchingStrategy(Action<EagerFetchingStrategy<TEntity>> strategyActions)
        {
            EagerFetchingStrategy<TEntity> strategy = new EagerFetchingStrategy<TEntity>();
            strategyActions(strategy);
            var paths = strategy.Paths.ToArray<Expression>();

            Guard.Against<ArgumentNullException>((paths == null) || (paths.Length == 0), "Expected a non-null and non-empty array of Expression instances representing the paths to eagerly load.");

            string currentPath = string.Empty;
            paths.ForEach<Expression>(delegate (Expression path) {
                MemberAccessPathVisitor visitor = new MemberAccessPathVisitor();
                visitor.Visit(path);
                currentPath = !string.IsNullOrEmpty(currentPath) ? (currentPath + "." + visitor.Path) : visitor.Path;
                ((EFCoreRepository<TEntity, TDataStore>)this)._includes.Add(currentPath);
            });
        }



        public IQueryable<TEntity> CreateQuery()
        {
            return this.ObjectSet.AsQueryable<TEntity>();
        }

        public override void Delete(TEntity entity)
        {
            this.ObjectSet.Remove(entity);
        }


        public override ICollection<TEntity> Find(ISpecification<TEntity> specification)
        {
            return this.FindCore(specification.Predicate).ToList();
        }

        public override ICollection<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        {
            return this.FindCore(expression).ToList();
        }

        public override IQueryable<TEntity> FindQuery(ISpecification<TEntity> specification)
        {
            return this.FindCore(specification.Predicate);
        }

        public override IQueryable<TEntity> FindQuery(Expression<Func<TEntity, bool>> expression)
        {
            return this.FindCore(expression);
        }

        private IQueryable<TEntity> FindCore(Expression<Func<TEntity, bool>> expression)
        {
            IQueryable<TEntity> queryable;
            try
            {
                Guard.Against<NullReferenceException>(this.RepositoryQuery == null, "RepositoryQuery is null");

                queryable = this.RepositoryQuery.Where<TEntity>(expression);
            }
            catch (Exception exception)
            {
                throw new RepositoryException("Error in Repository: " + base.GetType().ToString() + " while executing a query on the Context.", exception.GetBaseException());
            }
            return queryable;
        }

        /*private Task<IQueryable<TEntity>> FindCoreAsync(ISpecification<TEntity> specification)
        {
            IQueryable<TEntity> queryable;
            try
            {
                Guard.Against<NullReferenceException>(this.RepositoryQuery == null, "RepositoryQuery is null");

                queryable = this.RepositoryQuery.Where<TEntity>(specification.Predicate);
                this.ObjectSet.FindAsync()
            }
            catch (Exception exception)
            {
                throw new RepositoryException("Error in Repository: " + base.GetType().ToString() + " while executing a query on the Context.", exception.GetBaseException());
            }
            return queryable;
        }*/




        public override int GetCount(ISpecification<TEntity> selectSpec) =>
            this.Find(selectSpec).Count<TEntity>();

        public override int GetCount(Expression<Func<TEntity, bool>> expression) =>
            this.Find(expression).Count<TEntity>();

        /*private EntityKey GetEntityKey(TEntity entity)
        {
            List<EntityKeyMember> entityKeyValues = new List<EntityKeyMember>();
            using (ReadOnlyMetadataCollection<EdmMember>.Enumerator enumerator = this.ObjectSet.EntitySet.ElementType.KeyMembers.GetEnumerator())
            {
                while (true)
                {
                    if (!enumerator.MoveNext())
                    {
                        break;
                    }
                    EdmMember current = enumerator.Current;
                    object keyValue = entity.GetType().GetProperty(current.Name).GetValue(entity, null);
                    entityKeyValues.Add(new EntityKeyMember(current.Name, keyValue));
                }
            }
            return new EntityKey(this.ObjectContext.DefaultContainerName + "." + this.ObjectSet.EntitySet.Name, entityKeyValues);
        }*/

        private DbSet<T> GetObjectSet<T>() where T : class
        {
            object obj2 = null;
            if (!this._objectSets.TryGetValue(typeof(T), out obj2))
            {
                obj2 = this.ObjectContext.Set<T>();// CreateObjectSet<T>();
                this._objectSets.Add(typeof(T), obj2);
            }
            return (DbSet<T>)obj2;
        }

        /*private ObjectStateEntry GetObjectStateEntry(TEntity entity)
        {
            ObjectStateEntry entry = null;
            this.ObjectContext.ObjectStateManager.TryGetObjectStateEntry(this.GetEntityKey(entity), out entry);
            return entry;
        }

        private ObjectStateEntry GetObjectStateEntry(EntityKey entityKey)
        {
            ObjectStateEntry entry = null;
            this.ObjectContext.ObjectStateManager.TryGetObjectStateEntry(entityKey, out entry);
            return entry;
        }*/


        private int Save()
        {
            int num = 0;
            if (ReferenceEquals(UnitOfWorkManager.CurrentUnitOfWork, null))
            {
                num = this.ObjectContext.SaveChanges(true);
            }
            return num;
        }

        public override void Update(TEntity entity)
        {
            this.ObjectSet.Update(entity);
            this.Save();
        }

        public async override Task<ICollection<TEntity>> FindAsync(ISpecification<TEntity> specification)
        {
            return await this.FindCore(specification.Predicate).ToListAsync();
        }

        public async override Task<ICollection<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await this.FindCore(expression).ToListAsync();
        }

        public async override Task<int> GetCountAsync(ISpecification<TEntity> selectSpec)
        {
            return await this.FindCore(selectSpec.Predicate).CountAsync();
        }

        public async override Task<int> GetCountAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await this.FindCore(expression).CountAsync();
        }

        private async Task<int> SaveAsync()
        {
            int num = 0;
            if (ReferenceEquals(UnitOfWorkManager.CurrentUnitOfWork, null))
            {
                num = await this.ObjectContext.SaveChangesAsync(true);
            }
            return num;
        }

        public override void Attach(TEntity entity)
        {
            this.ObjectContext.Attach<TEntity>(entity);
            this.Save();
        }

        public override TEntity Find(object primaryKey)
        {
            return this.ObjectContext.Find<TEntity>(primaryKey);
        }

        public override TEntity FindSingleOrDefault(Expression<Func<TEntity, bool>> expression)
        {
            return this.FindCore(expression).SingleOrDefault();
        }

        public override TEntity FindSingleOrDefault(ISpecification<TEntity> specification)
        {
            return this.FindCore(specification.Predicate).SingleOrDefault();
        }

        public override async Task AddAsync(TEntity entity)
        {
            await this.ObjectSet.AddAsync(entity);
        }

        public override Task DeleteAsync(TEntity entity)
        {
            this.ObjectSet.Remove(entity);
            return Task.CompletedTask;
        }

        public override Task UpdateAsnyc(TEntity entity)
        {
            this.ObjectSet.Update(entity);
            return Task.CompletedTask;
        }

        public override async Task<TEntity> FindAsync(object primaryKey)
        {
            return await this.ObjectSet.FindAsync(primaryKey);
        }

        public override async Task<TEntity> FindSingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await this.FindCore(expression).SingleOrDefaultAsync();
        }

        public override async Task<TEntity> FindSingleOrDefaultAsync(ISpecification<TEntity> specification)
        {
            return await this.FindCore(specification.Predicate).SingleOrDefaultAsync();
        }

        protected ObjectSourceLifetimeManager<DbContext> LifetimeObjectContextManager =>
            this._objectContextLifetimeManager;

        protected internal DbContext ObjectContext
        {
            get
            {
                if (!ReferenceEquals(this._objectContext, null))
                {
                    Debug.WriteLine(this.GetType().ToString() + ": We're using an old ObjectContext now");
                }
                else
                {
                    Debug.WriteLine(this.GetType().ToString() + ": We're getting a new ObjectContext now");
                    this._objectContext = this._objectContextLifetimeManager.GetObjectSource(typeof(TDataStore));
                    //Guard.IsNotNull(this.ContextName, "ContextName");
                    //Guard.IsNotNull(this._objectContext.Database.GetDbConnection(), "_ObjectContext.Connection");
                    if (!this._objectContext.Database.CanConnect())
                    {

                        throw new RepositoryException("Cannot successfully connect to this DbContext. " + this._objectContext.GetType().ToString(), new ArgumentNullException());
                    }
                }
                return this._objectContext;
            }
        }

        /*public override string ContextName
        {
            get =>
                _contextName;
            set
            {
                //throw new RepositoryException("This version of the EntityRepository does not have the ability to dynamically set the ContextName at runtime. Use the upgraded version.", new NotImplementedException());
                _contextName = value;
            }
        }*/



        protected DbSet<TEntity> ObjectSet
        {
            get
            {
                if (ReferenceEquals(this._objectSet, null))
                {
                    this._objectSet = this.GetObjectSet<TEntity>();
                }
                return this._objectSet;
            }
        }

        public bool Tracking
        {
            get =>
                this._tracking;
            set
            {
                this._tracking = value;
            }

        }

        protected override IQueryable<TEntity> RepositoryQuery
        {
            get
            {
                if (ReferenceEquals(this._repositoryQuery, null))
                {
                    Action<string> action = null;
                    IQueryable<TEntity> query = this.CreateQuery();
                    if (this._includes.Count > 0)
                    {
                        if (action == null)
                        {
                            action = delegate (string m) {
                                query = query.Include(m);
                            };
                        }
                        this._includes.ForEach(action);
                    }
                    this._repositoryQuery = query;
                }
                return this._repositoryQuery;
            }
        }

        /*protected override IQueryable<TEntity> RepositoryQuery2
        {
            get
            {
                if (ReferenceEquals(this._repositoryQuery, null))
                {
                    Action<string> action = null;
                    //IQueryable<TEntity> query = this.CreateQuery();
                    if (this._includes.Count > 0)
                    {
                        if (action == null)
                        {
                            action = delegate (string m) {
                                this.ObjectSet.Include(m);
                            };
                        }
                        this._includes.ForEach(action);
                    }
                    this._repositoryQuery = this.ObjectSet.AsQueryable();
                }
                return this._repositoryQuery;
            }
        }*/

        protected string EntitySetName =>
            this.ObjectContext.GetType().GetProperties().Single<PropertyInfo>(delegate (PropertyInfo p) {
                bool flag1;
                if (!p.PropertyType.IsGenericType)
                {
                    flag1 = false;
                }
                else
                {
                    Type[] typeArguments = new Type[] { typeof(TEntity) };
                    flag1 = typeof(IQueryable<>).MakeGenericType(typeArguments).IsAssignableFrom(p.PropertyType);
                }
                return flag1;
            }).Name;


    }
}

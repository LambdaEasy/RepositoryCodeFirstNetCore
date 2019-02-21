using Lambda.Domain;
using Lambda.Domain.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;

namespace Lambda.Core
{
    public class SqlObjectContext : DbContext
    {
        #region Method DbSet

        public DbSet<Example> Examples { get; set; }

        #endregion


        #region Cto
        public SqlObjectContext() : base()
        {

        }

        public SqlObjectContext(DbContextOptions<SqlObjectContext> options) : base(options)
        {

        }

        #endregion

        #region Override Method

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            base.OnModelCreating(modelBuilder);
        }

        #endregion

        #region Methods


        protected virtual string CreateSqlWithParameters(string sql, params object[] parameters)
        {
            //add parameters to sql
            for (var i = 0; i <= (parameters?.Length ?? 0) - 1; i++)
            {
                if (!(parameters[i] is DbParameter parameter))
                    continue;

                sql = $"{sql}{(i > 0 ? "," : string.Empty)} @{parameter.ParameterName}";

                //whether parameter is output
                if (parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Output)
                    sql = $"{sql} output";
            }

            return sql;
        }


        public virtual new DbSet<T> Set<T, TKey>() where T : BaseEntity<TKey>
        {
            return base.Set<T>();
        }


        public virtual string GenerateCreateScript()
        {
            return this.Database.GenerateCreateScript();
        }


        public virtual IQueryable<TQuery> QueryFromSql<TQuery>(string sql) where TQuery : class
        {
            return this.Query<TQuery>().FromSql(sql);
        }


        public virtual IQueryable<T> EntityFromSql<T, TKey>(string sql, params object[] parameters) where T : BaseEntity<TKey>
        {
            return this.Set<T, TKey>().FromSql(CreateSqlWithParameters(sql, parameters), parameters);
        }


        public virtual int ExecuteSqlCommand(RawSqlString sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters)
        {
            //set specific command timeout
            var previousTimeout = this.Database.GetCommandTimeout();
            this.Database.SetCommandTimeout(timeout);

            var result = 0;
            if (!doNotEnsureTransaction)
            {
                //use with transaction
                using (var transaction = this.Database.BeginTransaction())
                {
                    result = this.Database.ExecuteSqlCommand(sql, parameters);
                    transaction.Commit();
                }
            }
            else
                result = this.Database.ExecuteSqlCommand(sql, parameters);

            //return previous timeout back
            this.Database.SetCommandTimeout(previousTimeout);

            return result;
        }


        public virtual void Detach<T, TKey>(T entity) where T : BaseEntity<TKey>
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var entityEntry = this.Entry(entity);
            if (entityEntry == null)
                return;

            //set the entity is not being tracked by the context
            entityEntry.State = EntityState.Detached;
        }

        #endregion
    }
}

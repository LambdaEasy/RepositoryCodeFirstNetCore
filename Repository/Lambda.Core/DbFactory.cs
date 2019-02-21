
using Microsoft.EntityFrameworkCore;

namespace Lambda.Core
{
    public class DbFactory : IDbFactory
    {
        #region Ctor

        public DbFactory(SqlObjectContext ContextFactory)
        {
            _dataContext = ContextFactory;
        }

        #endregion

        #region Property Private

        private SqlObjectContext _dataContext;

        #endregion

        #region Events Public

        public SqlObjectContext Get()
        {
            return _dataContext ?? (_dataContext = new SqlObjectContext());
        }

        #endregion
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lambda.Core
{
    public class SqlObjectContext: DbContext
    {
        #region Cto
        public SqlObjectContext(): base()
        {

        }

        public SqlObjectContext(DbContextOptions<SqlObjectContext> options) : base(options)
        {

        }

        #endregion
    }
}

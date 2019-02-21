using Lambda.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lambda.Repository
{
    public class ContextFactory: IDesignTimeDbContextFactory<SqlObjectContext>
    {
    
        public SqlObjectContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SqlObjectContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-E5ULD96\\SQL2012;Initial Catalog=Example;Persist Security Info=True;User ID=sa;Password=sa.sa", b=>b.MigrationsAssembly("Lambda.Repository"));

            return new SqlObjectContext(optionsBuilder.Options);
        }

        public SqlObjectContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SqlObjectContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-E5ULD96\\SQL2012;Initial Catalog=Example;Persist Security Info=True;User ID=sa;Password=sa.sa", b => b.MigrationsAssembly("Lambda.Repository"));

            return new SqlObjectContext(optionsBuilder.Options);
        }
    }
}

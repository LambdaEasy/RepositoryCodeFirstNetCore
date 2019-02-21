using System;
using System.Collections.Generic;
using System.Text;

namespace Lambda.Core
{
    public partial interface IDbFactory
    {
        SqlObjectContext Get();
    }
}

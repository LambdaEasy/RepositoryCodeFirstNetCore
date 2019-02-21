using Lambda.Domain;
using Lambda.Core;

namespace Lambda.Repository
{
    public class ExampleRepository: Lambda.Core.Repository<Example,int>, IExampleRepository
    {
        public ExampleRepository(IDbFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
}

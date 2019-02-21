using Lambda.Core;
using Lambda.Repository;
using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var ContextFactory = new ContextFactory();
         
            DbFactory dbFactory = new DbFactory(ContextFactory.CreateDbContext());

            ExampleRepository exampleRepository = new ExampleRepository(dbFactory);

            exampleRepository.Insert(new Lambda.Domain.Example
            {
                Name = "Hola"
            });
        }
    }
}

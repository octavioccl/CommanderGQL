using System.Linq;
using CommanderGQL.Data;
using CommanderGQL.Model;
using HotChocolate;
using HotChocolate.Data;

namespace CommanderGQL.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context)
        {
            return context.Platforms;
        }

        [UseDbContext(typeof(AppDbContext))]
        //[UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Command> GetCommand([ScopedService] AppDbContext context)
        {
            return context.Commands;
        }
    }
}
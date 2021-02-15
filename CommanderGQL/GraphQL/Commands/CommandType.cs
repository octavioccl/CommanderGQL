using System.Linq;
using CommanderGQL.Data;
using CommanderGQL.Model;
using HotChocolate;
using HotChocolate.Types;

namespace CommanderGQL.GraphQL.Commands
{
    public class CommandType: ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor.Description("Represent a executable command");
        

            descriptor.Field(p => p.Platform)
                      .ResolveWith<Resolvers>(p => p.GetPlatform(default!, default!))
                      .UseDbContext<AppDbContext>()
                      .Description("Platform where the command belongs");
        }
        private class Resolvers
        {
            public Platform GetPlatform(Command command, [ScopedService] AppDbContext context)
            {
                return context.Platforms.FirstOrDefault(p=> p.Id == command.PlatformId);
            }
        }
    }
}
using System.Linq;
using CommanderGQL.Data;
using CommanderGQL.Model;
using HotChocolate;
using HotChocolate.Types;

namespace CommanderGQL.GraphQL.Platforms
{
    public class PlatformType : ObjectType<Platform>
    {
        protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
        {
            descriptor.Description("Represent any Software or Service that has a command line insterface");
            //descriptor.Field(p=>p.LicenseKey).Ignore();

            descriptor.Field(p=>p.Commands)
                      .ResolveWith<Resolvers>(p=>p.GetCommands(default!, default!))
                      .UseDbContext<AppDbContext>()
                      .Description("This is the list of available commands for this platform");
        }
        private class Resolvers{
            public IQueryable<Command> GetCommands(Platform platform, [ScopedService] AppDbContext context){
                return context.Commands.Where(c=> c.PlatformId==platform.Id);
            }
        }
    }
}
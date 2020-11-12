using Autofac;
using Discord.Commands;

namespace Erza.Discord.Server.Factories
{
    public class FactoryCommandService : IFactoryCommandService
    {
        private readonly ILifetimeScope _lifetimeScope;

        public FactoryCommandService(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public CommandService CreateCommandService()
        {
            var commandService = new CommandService();

            return commandService;
        }

        public void ConfigureCommandService(CommandService commandService)
        {
            var logger = _lifetimeScope.Resolve<ILogger>();
            var commandHandling = _lifetimeScope.Resolve<CommandHandling>();

            commandService.Log += logger.LogAsync;
            commandService.CommandExecuted += commandHandling.CommandExecutedAsync;
        }
    }
}
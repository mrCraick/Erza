using Autofac;
using Discord.WebSocket;

namespace Erza.Discord.Server.Factories
{
    public class FactoryDiscordSocketClient : IFactoryDiscordSocketClient
    {
        private readonly ILifetimeScope _lifetimeScope;

        public FactoryDiscordSocketClient(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public DiscordSocketClient CreateDiscordSocketClient()
        {
            var discordSocketClient = new DiscordSocketClient();

            return discordSocketClient;
        }

        public void ConfigureDiscordSocketClient(DiscordSocketClient discordSocketClient)
        {
            var logger = _lifetimeScope.Resolve<ILogger>();
            var commandHandling = _lifetimeScope.Resolve<CommandHandling>();

            discordSocketClient.Log += logger.LogAsync;
            discordSocketClient.MessageReceived += commandHandling.MessageReceivedAsync;
        }
    }
}
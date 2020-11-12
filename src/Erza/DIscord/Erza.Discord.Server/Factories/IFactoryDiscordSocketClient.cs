using Discord.WebSocket;

namespace Erza.Discord.Server.Factories
{
    public interface IFactoryDiscordSocketClient
    {
        DiscordSocketClient CreateDiscordSocketClient();

        void ConfigureDiscordSocketClient(DiscordSocketClient discordSocketClient);
    }
}
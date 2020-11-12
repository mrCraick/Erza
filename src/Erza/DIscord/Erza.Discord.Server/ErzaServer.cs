using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace Erza.Discord.Server
{
    public class ErzaServer : IErzaServer
    {
        private readonly DiscordSocketClient _discordSocketClient;

        public ErzaServer(DiscordSocketClient discordSocketClient)
        {
            _discordSocketClient = discordSocketClient;
        }

        public async Task Start()
        {
            await _discordSocketClient.LoginAsync(TokenType.Bot, "Nzc2NDI5NTExMDY2NTE3NTM0.X60wVA.Okpvz8Mo7r429wclasXZpqbjnDI");
            await _discordSocketClient.StartAsync();
            await Task.Delay(Timeout.Infinite);
        }
    }
}
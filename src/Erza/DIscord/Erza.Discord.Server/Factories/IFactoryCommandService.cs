using Discord.Commands;

namespace Erza.Discord.Server.Factories
{
    public interface IFactoryCommandService
    {
        CommandService CreateCommandService();

        void ConfigureCommandService(CommandService commandService);
    }
}
using Autofac;
using Autofac.Core;
using Discord.WebSocket;

namespace Erza.Discord.Server.Factories
{
    public class FactoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder
                .RegisterType<FactoryDiscordSocketClient>()
                .As<IFactoryDiscordSocketClient>()
                .SingleInstance(); 
            
            builder
                .RegisterType<FactoryCommandService>()
                .As<IFactoryCommandService>()
                .SingleInstance();

            builder
                .Register(x =>
                {
                    var factory = x.Resolve<IFactoryDiscordSocketClient>();

                    return factory.CreateDiscordSocketClient();
                })
                .OnActivated(args => args.Context.Resolve<IFactoryDiscordSocketClient>().ConfigureDiscordSocketClient(args.Instance));

            builder
                .Register(x =>
                {
                    var factory = x.Resolve<IFactoryCommandService>();

                    return factory.CreateCommandService();
                })
                .OnActivated(args => args.Context.Resolve<IFactoryCommandService>().ConfigureCommandService(args.Instance));
        }
    }
}
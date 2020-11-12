using System;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Erza.Discord.Server.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace Erza.Discord.Server
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var container = ConfigureContainer();

            await using var scope = container.BeginLifetimeScope();

            var erzaServer = container.Resolve<IErzaServer>();

            await erzaServer.Start();
        }

        private static IContainer ConfigureContainer()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<ConsoleLogger>().As<ILogger>();

            containerBuilder.RegisterModule<FactoriesModule>();

            containerBuilder
                .RegisterType<ErzaServer>()
                .As<IErzaServer>()
                .SingleInstance();

            containerBuilder
                .RegisterType<CommandHandling>()
                .SingleInstance();

            containerBuilder
                .Register(x => new AutofacServiceProvider(x.Resolve<ILifetimeScope>()))
                .As<IServiceProvider>();

            return containerBuilder.Build();
        }
    }
}

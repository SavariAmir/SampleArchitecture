using Anshan.Framework.Application.Command;
using Anshan.Framework.Core;
using Anshan.Framework.Core.Events;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace Anshan.Framework.DI
{
    public class FrameworkBootstrapper
    {
        public static void Bootstrap(IServiceCollection services, string connectionStringKey)
        {
            services.AddScoped<IServiceLocator, DotNetCoreServiceLocatorAdapter>();

            services.AddScoped<ICommandBus, CommandBus>();

            services.AddScoped<IDbConnection>((sp) => new SqlConnection(connectionStringKey));

            services.AddTransient(typeof(TransactionalCommandHandlerDecorator<>));

            var eventAggregator = new EventAggregator();
            services.AddSingleton<IEventListener>(eventAggregator);
            services.AddSingleton<IEventPublisher>(eventAggregator);
        }
    }
}
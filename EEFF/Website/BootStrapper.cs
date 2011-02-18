using System;
using Commands;
using Ncqrs;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;
using Ncqrs.Commanding.ServiceModel;
using Ncqrs.Eventing.ServiceModel.Bus;
using Ncqrs.Eventing.Storage;
using Ncqrs.Eventing.Storage.SQL;

namespace Website
{
    public class BootStrapper
    {
        public static void BootUp()
        {
            var config = new Ncqrs.Config.StructureMap.StructureMapConfiguration(cfg =>
            {
                cfg.For<ICommandService>().Use(InitializeCommandService);
                cfg.For<IEventBus>().Use(x => InitializeEventBus());
                cfg.For<IEventStore>().Use(InitializeEventStore);
            });

            NcqrsEnvironment.Configure(config);
        }

        private static ICommandService InitializeCommandService()
        {
            var commandAssembly = typeof(CreateCustomer).Assembly;

            var service = new CommandService();
            service.RegisterExecutorsInAssembly(commandAssembly);

            return service;
        }

        private static IEventStore InitializeEventStore()
        {
            var store = new MsSqlServerEventStore(@"Data Source=.\SQLEXPRESS;Initial Catalog=EeffEventStore;Integrated Security=True");
            return store;
        }

        private static IEventBus InitializeEventBus()
        {
            var bus = new InProcessEventBus();

            bus.RegisterAllHandlersInAssembly(typeof(BootStrapper).Assembly);

            return bus;
        }
    }
}
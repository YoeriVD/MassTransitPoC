using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.Testing.TestActions;
using Messages.Schema;
using ToDoService.Consumers;

namespace ToDoService
{
    class ServiceBusManager
    {
        private static IServiceBus _bus;

        public static void Initialize()
        {
            _bus = MassTransit.ServiceBusFactory.New(cfg =>
            {
                cfg.UseRabbitMq(
                    mqcfg => mqcfg.ConfigureHost(new Uri("rabbitmq://Konijn:wortel@localhost/ToDoService"), hostcfg =>
                    {
                        hostcfg.SetUsername("Konijn");
                        hostcfg.SetPassword("wortel");
                    }));
                cfg.ReceiveFrom("rabbitmq://localhost/ToDoService");
                cfg.Subscribe(config =>
                {
                    config.Consumer<NewTodoConsumer>();
                    config.Consumer<GetTodoListRequestConsumer>();
                });
            });
        }

        public static void Send(IToDoList list)
        {
            _bus.Publish(list);
        }
    }
}

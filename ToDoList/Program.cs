using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using Messages.Implementation;
using RabbitMQ.Client.Events;
using ToDoList.Consumers;

namespace ToDoList
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = MassTransit.ServiceBusFactory.New(busConfig =>
            {
                busConfig.UseRabbitMq(mqConfig => mqConfig.ConfigureHost(new Uri("rabbitmq://Konijn:wortel@localhost/ToDoList"), hostConfig =>
                {
                    hostConfig.SetUsername("Konijn");
                    hostConfig.SetPassword("wortel");
                }));
                busConfig.ReceiveFrom("rabbitmq://localhost/ToDoList");
                busConfig.Subscribe(configure => configure.Consumer<ToDoListConsumer>());
            });

            Console.WriteLine("Getting todos...");
            bus.Publish(new GetTodoListRequest{Count = 10});
        }
    }
}

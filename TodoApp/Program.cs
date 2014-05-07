using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magnum.Extensions;
using MassTransit;
using Messages.Schema;

namespace TodoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            

            var bus = MassTransit.ServiceBusFactory.New(busConfig =>
            {
                busConfig.UseRabbitMq(mqConfig => mqConfig.ConfigureHost(new Uri("rabbitmq://Konijn:wortel@localhost/ToDoApp"), hostConfig =>
                {
                    hostConfig.SetUsername("Konijn");
                    hostConfig.SetPassword("wortel");
                }));
                busConfig.ReceiveFrom("rabbitmq://localhost/ToDoApp");
            });

            bus.PublishRequest(new Messages.Implementation.NewTodo { Content = "iets", DateAdded = DateTime.Now },
                c =>
                {
                    c.Handle<IToDoList>(list => Console.WriteLine(list.ToDos.Count().ToString()));
                    c.HandleFault(fault => Console.WriteLine(fault.FaultType.ToString()));
                    c.SetTimeout(24.Seconds());
                });

            Console.WriteLine("Todo?:");
            var response = Console.ReadLine();
            bus.PublishRequest(new Messages.Implementation.NewTodo { Content = response, DateAdded = DateTime.Now },
                c =>
                {
                    c.Handle<IToDoList>(list => Console.WriteLine(list.ToDos.Count().ToString()));
                    c.HandleFault(fault => Console.WriteLine(fault.FaultType.ToString()));
                    c.SetTimeout(24.Seconds());
                });

            Console.WriteLine("message sent");

        }
    }
}

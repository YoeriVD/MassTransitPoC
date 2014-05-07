using System;
using MassTransit;
using Messages.Schema;
using System.Linq;

namespace ToDoList.Consumers
{
    class ToDoListConsumer : Consumes<IToDoList>.All
    {
        public void Consume(IToDoList message)
        {
            Console.WriteLine("Message received: " + DateTime.Now.ToShortTimeString());
            message.ToDos.ToList().ForEach(item => Console.WriteLine(item.Content));
        }
    }
}

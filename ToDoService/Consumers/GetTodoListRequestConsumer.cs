using System;
using System.Collections.Generic;
using MassTransit;
using Messages.Implementation;
using Messages.Schema;

namespace ToDoService.Consumers
{
    internal class GetTodoListRequestConsumer : Consumes<IGetTodoListRequest>.All
    {
        public void Consume(IGetTodoListRequest message)
        {
            Console.WriteLine("Request for " + message.Count + " items");
            ServiceBusManager.Send(new ToDoList { ToDos = Program.TodosList });
        }
    }
}
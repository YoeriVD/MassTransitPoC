using System;
using MassTransit;
using Messages.Implementation;
using Messages.Schema;

namespace ToDoService.Consumers
{
    internal class NewTodoConsumer : Consumes<INewTodo>.Context
    {
        public void Consume(IConsumeContext<INewTodo> messageContext)
        {
            var message = messageContext.Message;
            Console.WriteLine("message received:" + message.Content);
            Program.TodosList.Add(new ToDo() { Content = message.Content });
            throw new InvalidOperationException("testExc");
            messageContext.Respond(new ToDoList() { ToDos = Program.TodosList });
        }
    }
}
using System;
using System.Collections.Generic;
using MassTransit;
using Messages.Implementation;
using Messages.Schema;
using ToDoService.Consumers;

namespace ToDoService
{
    class Program
    {
        public static IList<IToDo> TodosList = new List<IToDo>();
        static void Main(string[] args)
        {
            ServiceBusManager.Initialize();
            Console.WriteLine("bus started...");
            Console.ReadKey();
        }
    }
}

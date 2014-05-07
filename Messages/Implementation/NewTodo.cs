using System;
using Messages.Schema;

namespace Messages.Implementation
{
    public class NewTodo : INewTodo
    {
        public DateTime DateAdded { get; set; }
        public string Content { get; set; }
    }
}
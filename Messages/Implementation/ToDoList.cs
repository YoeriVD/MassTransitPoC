using System.Collections.Generic;
using Messages.Schema;

namespace Messages.Implementation
{
    public class ToDoList : IToDoList
    {
        public IEnumerable<IToDo> ToDos { get; set; }
    }
}
using Messages.Schema;

namespace Messages.Implementation
{
    public class ToDo : IToDo
    {
        public string Content { get; set; }
    }
}
using Messages.Schema;

namespace Messages.Implementation
{
    public class GetTodoListRequest : IGetTodoListRequest
    {
        public int Count { get; set; }

    }
}
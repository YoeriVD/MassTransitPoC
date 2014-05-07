using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messages.Implementation;

namespace Messages.Schema
{
    public interface IToDoList
    {
        IEnumerable<IToDo> ToDos { get; set; }
    }
}

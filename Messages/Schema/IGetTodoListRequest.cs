﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Messages.Schema
{
    public interface IGetTodoListRequest
    {
        int Count { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer
{
    public interface IProcessor
    {
        void DoGet(string url);
        void DoPost();
    }
}

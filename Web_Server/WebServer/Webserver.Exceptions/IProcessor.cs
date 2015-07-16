using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Model;

namespace WebServer.Interface
{
    public interface IProcessor
    {
        string TypesIncluded { get; }
        Response Process(Request request);
    }
}
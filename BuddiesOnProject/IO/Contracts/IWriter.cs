using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddiesOnProject.IO.Contracts
{
    internal interface IWriter
    {
        void WriteLine(string message);
    }
}

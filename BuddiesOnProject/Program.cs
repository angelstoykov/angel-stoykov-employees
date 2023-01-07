using BuddiesOnProject.Core;
using Microsoft.VisualBasic.FileIO;
using System.IO;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;

namespace BuddiesOnProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var engine = new Engine();
            engine.Run();
        }
    }
}
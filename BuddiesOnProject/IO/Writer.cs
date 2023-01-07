using BuddiesOnProject.IO.Contracts;

namespace BuddiesOnProject.IO
{
    internal class Writer : IWriter
    {
        public void WriteLine(string message) => Console.WriteLine(message);
    }
}

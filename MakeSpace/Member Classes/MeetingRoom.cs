using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeSpace.Member_Classes
{
    public interface IMeetingRoom
    {
        int Capacity { get; }
        string Name { get; }
    }

    public class MeetingRoom : IMeetingRoom
    {
        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public MeetingRoom(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }
    }
}

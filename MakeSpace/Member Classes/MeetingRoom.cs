using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeSpace.Member_Classes
{
    public class MeetingRoom
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public MeetingRoom(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }
    }
}

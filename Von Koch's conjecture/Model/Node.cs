using System;
using System.Collections.Generic;
using System.Text;

namespace Von_Koch_s_conjecture.Model
{
    public class Node
    {
        public string Name { get; set; }

        public int UniqueId { get; set; }

        public List<string> Connections { get; set; }
    }
}

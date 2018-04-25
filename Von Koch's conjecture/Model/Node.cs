using System.Collections.Generic;

namespace Von_Koch_s_conjecture.Model
{
    public class Node
    {
        public string Name { get; set; }

        public int UniqueId { get; set; }

        public List<string> Connections { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Von_Koch_s_conjecture.Model
{
    public class Tree
    {
        private List<Node> _store;

        public Tree()
        {
            _store = new List<Node>();
        }

        public void AddNode(Node node)
        {
            _store.Add(node);
        }

        public List<Node> GetAllNodes()
        {
            return _store;
        }

        public List<Node> GetAllConnections(Node node)
        {
            return _store.Where(
                n => (n.Name.Equals(node.Name) == false && n.Connections.Contains(node.Name))).ToList();
        }
    }
}

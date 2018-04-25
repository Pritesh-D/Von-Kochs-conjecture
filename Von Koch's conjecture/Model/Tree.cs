using System;
using System.Collections.Generic;
using System.Linq;

namespace Von_Koch_s_conjecture.Model
{
    public class Tree : ICloneable
    {
        private List<Node> _store;

        public Tree()
        {
            _store = new List<Node>();
        }

        protected Tree(Tree another)
        {
            _store = new List<Node>(another.GetAllNodes());
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

        public object Clone()
        {
            return new Tree(this);
        }
    }
}

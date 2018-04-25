using System;
using System.Collections.Generic;
using Von_Koch_s_conjecture;
using Von_Koch_s_conjecture.Model;
using Xunit;
using System.Linq;
using System.Data;

namespace Test
{
    public class ConjectureTest
    {
        [Fact]
        public void Test1()
        {
            var idGenerator = new UniqueIdGenerator();
            Assert.True(HasValidIds(idGenerator.Generate(SampleInput1())));
        }

        [Fact]
        public void Test2()
        {
            var idGenerator = new UniqueIdGenerator();
            Assert.True(HasValidIds(idGenerator.Generate(SampleInput2())));
        }

        private static bool HasValidIds(Tree tree)
        {
            var paths = new List<string>();
            var uniquePathIds = new List<int>();
            var nodes = tree.GetAllNodes();
            var pathId = 0;
            Node connectedNode = null;
            try
            {
                nodes.ForEach(n =>
                {
                    tree.GetAllConnections(n)
                    .ForEach(c =>
                    {
                        if (!(paths.Contains(string.Format("{0}{1}", n.Name, c.Name)) || paths.Contains(string.Format("{0}{1}", c.Name, n.Name))))
                        {
                            paths.Add(string.Format("{0}{1}", n.Name, c.Name));
                            pathId = n.UniqueId - c.UniqueId;
                            pathId = pathId > 0 ? pathId : (pathId * -1);
                            if (uniquePathIds.Contains(pathId) == false)
                                uniquePathIds.Add(pathId);
                            else
                                throw new DuplicateNameException();
                        }
                    });
                });
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private static Tree SampleInput1()
        {
            var input = new Tree();
            input.AddNode(new Node()
            {
                Name = "d",
                Connections = new List<string>() { "a" },
            });
            input.AddNode(new Node()
            {
                Name = "a",
                Connections = new List<string>() { "d", "b", "g" },
            });

            input.AddNode(new Node()
            {
                Name = "g",
                Connections = new List<string>() { "a" },
            });

            input.AddNode(new Node()
            {
                Name = "b",
                Connections = new List<string>() { "a", "c", "e" },
            });

            input.AddNode(new Node()
            {
                Name = "e",
                Connections = new List<string>() { "b", "f" },
            });

            input.AddNode(new Node()
            {
                Name = "f",
                Connections = new List<string>() { "e" },
            });

            input.AddNode(new Node()
            {
                Name = "c",
                Connections = new List<string>() { "b" },
            });
            return input;
        }

        private static Tree SampleInput2()
        {
            var input = new Tree();
            input.AddNode(new Node()
            {
                Name = "a",
                Connections = new List<string>() { "g", "i", "h", "b", "c" },
            });
            input.AddNode(new Node()
            {
                Name = "g",
                Connections = new List<string>() { "a" },
            });
            input.AddNode(new Node()
            {
                Name = "i",
                Connections = new List<string>() { "a" },
            });
            input.AddNode(new Node()
            {
                Name = "h",
                Connections = new List<string>() { "a" },
            });
            input.AddNode(new Node()
            {
                Name = "b",
                Connections = new List<string>() { "a" },
            });
            input.AddNode(new Node()
            {
                Name = "c",
                Connections = new List<string>() { "a", "d", "e", "f" },
            });
            input.AddNode(new Node()
            {
                Name = "f",
                Connections = new List<string>() { "c" },
            });

            input.AddNode(new Node()
            {
                Name = "d",
                Connections = new List<string>() { "c", "k" },
            });

            input.AddNode(new Node()
            {
                Name = "k",
                Connections = new List<string>() { "d" },
            });

            input.AddNode(new Node()
            {
                Name = "e",
                Connections = new List<string>() { "c", "q" },
            });

            input.AddNode(new Node()
            {
                Name = "q",
                Connections = new List<string>() { "m", "n", "e" },
            });

            input.AddNode(new Node()
            {
                Name = "m",
                Connections = new List<string>() { "q" },
            });

            input.AddNode(new Node()
            {
                Name = "n",
                Connections = new List<string>() { "q", "p" },
            });
            input.AddNode(new Node()
            {
                Name = "p",
                Connections = new List<string>() { "n" },
            });
            return input;
        }
    }
}
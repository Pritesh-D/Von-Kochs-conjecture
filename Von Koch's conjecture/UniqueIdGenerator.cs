using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Von_Koch_s_conjecture.Model;

namespace Von_Koch_s_conjecture
{
    public class UniqueIdGenerator
    {
        public Tree Generate(Tree input)
        {
            while (HasValidIds(input) == false)
            {
                var idBucket = new List<int>();
                input.GetAllNodes().ForEach(n =>
                {
                    int id = GetUniqueNumber(input, idBucket);
                    n.UniqueId = id;
                });
            }
            return input;
        }

        private int GetUniqueNumber(Tree input, List<int> idBucket)
        {
            var random = new Random();
            var id = random.Next(1, input.GetAllNodes().Count());
            while (idBucket.Contains(id))
                id = random.Next(1, input.GetAllNodes().Count() + 1);
            idBucket.Add(id);
            return id;
        }

        private bool HasValidIds(Tree tree)
        {
            var paths = new List<string>();
            var uniquePathIds = new List<int>();
            var nodes = tree.GetAllNodes();
            var pathId = 0;
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
    }
}

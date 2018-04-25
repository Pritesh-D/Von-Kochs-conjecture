using System;
using System.Collections.Generic;
using System.Threading;
using Von_Koch_s_conjecture.Model;

namespace Von_Koch_s_conjecture
{
    public class UniqueIdGenerator
    {
        private int parallelExecutorCount = 100;
        private Object thisLock = new Object();

        public Tree Generate(Tree input)
        {
            var lstThreads = new List<Thread>();
            var isAnySuccess = false;
            Tree result = null;
            for (var i = 0; i < parallelExecutorCount; i++)
            {
                Thread th = new Thread(() =>
                {
                    var util = new UniqueIdGeneratorUtilities();
                    lock (thisLock)
                    {
                        if (isAnySuccess == false)
                            result = util.PTask(input.Clone() as Tree);
                        isAnySuccess = true;
                    }
                });
                lstThreads.Add(th);
                th.Start();
            }

            while (isAnySuccess == false) ;
            lstThreads.ForEach(th =>
            {
                try
                {
                    th.Abort();
                }
                catch (Exception)
                {
                }
            });

            return result;
        }
    }
}

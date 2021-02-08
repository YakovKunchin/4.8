using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {
        static async Task Main()
        {
            await new Task1().Execute();
        }
    }

    public class Task1
    {
        public async Task Execute()
        {
            var timeByRow = new List<long>();

            var timeByColumn = new List<long>();

            for (var i = 0; i <= 12000; i += 500)
            {
                var byRow = TimeItTakes(() => { new int[i, i].FillArrayByRow(); });
                timeByRow.Add(byRow);

                var byColumn = TimeItTakes(() => { new int[i, i].FillArrayByColumn(); });
                timeByColumn.Add(byColumn);
            }

            await WriteResults(timeByRow, timeByColumn);
        }

        private async Task WriteResults(List<long> timeByRow, List<long> timeByColumn)
        {
            await using var sw1 = new StreamWriter($"./{nameof(timeByRow)}.txt");
            await sw1.WriteAsync(timeByRow.Select(x => x.ToString()).Aggregate((s1, s2) => s1 + ", " + s2));
            
            await using var sw2 = new StreamWriter($"./{nameof(timeByColumn)}.txt");
            await sw2.WriteAsync(timeByColumn.Select(x => x.ToString()).Aggregate((s1, s2) => s1 + ", " + s2));
        }

        private long TimeItTakes(Action action)
        {
            Stopwatch st = new();
            st.Start();
            
            action.Invoke();
            
            st.Stop();

            return st.ElapsedMilliseconds;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace lab1
{
    public class Task1
    {
        public async Task Execute()
        {
            var timeByRow = new List<long>();

            var timeByColumn = new List<long>();
            
            var computer = new Computer();
            
            for (var i = 0; i <= 12_000; i += 500)
            {
                var byRow = computer.TimeItTakes(() => { new int[i, i].FillArrayByRow(); });
                timeByRow.Add(byRow);

                var byColumn = computer.TimeItTakes(() => { new int[i, i].FillArrayByColumn(); });
                timeByColumn.Add(byColumn);
            }
            
            await new ResultWriter().Write(new List<KeyValuePair<string, List<long>>>()
            {
                KeyValuePair.Create($"{nameof(Task1)} {nameof(timeByRow)}", timeByRow),
                KeyValuePair.Create($"{nameof(Task1)} {nameof(timeByColumn)}", timeByColumn)
            });
        }
    }
}
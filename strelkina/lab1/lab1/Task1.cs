using System.Collections.Generic;
using System.Threading.Tasks;

namespace lab1
{
    public class Task1
    {
        public async Task Execute()
        {
            var timeByRowForInt = new List<long>();

            var timeByColumnForInt = new List<long>();
            
            var timeByRowForFloat = new List<long>();
            
            var timeByColumnForFloat = new List<long>();
            
            var computer = new Computer();
            
            for (var i = 0; i <= 12_000; i += 500)
            {
                var byRowForInt = computer.TimeItTakes(() => { new int[i, i].FillArrayByRow(); });
                timeByRowForInt.Add(byRowForInt);

                var byColumnForInt = computer.TimeItTakes(() => { new int[i, i].FillArrayByColumn(); });
                timeByColumnForInt.Add(byColumnForInt);
                
                var byRowForFloat = computer.TimeItTakes(() => { new int[i, i].FillArrayByRow(); });
                timeByRowForFloat.Add(byRowForFloat);

                var byColumnForFloat = computer.TimeItTakes(() => { new int[i, i].FillArrayByColumn(); });
                timeByColumnForFloat.Add(byColumnForFloat);
            }
            
            await new ResultWriter().Write(new List<KeyValuePair<string, List<long>>>()
            {
                KeyValuePair.Create($"{nameof(Task1)} {nameof(timeByRowForInt)}", timeByRowForInt),
                KeyValuePair.Create($"{nameof(Task1)} {nameof(timeByColumnForInt)}", timeByColumnForInt),
                KeyValuePair.Create($"{nameof(Task1)} {nameof(timeByRowForFloat)}", timeByRowForFloat),
                KeyValuePair.Create($"{nameof(Task1)} {nameof(timeByColumnForFloat)}", timeByColumnForFloat)
            });
        }
    }
}
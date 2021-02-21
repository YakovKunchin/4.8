using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lab1
{
    public class Task2
    {
        public async Task Execute()
        {
            var timeByVariant1 = new List<long>();

            var timeByVariant2 = new List<long>();
            
            var timeByVariant3 = new List<long>();
            
            var computer = new Computer();
            
            for (var i = 0; i <= 1_200_000; i += 50000)
            {
                var byVariant1 = computer.TimeItTakes(() => { new double[i].Variant1(); });
                timeByVariant1.Add(byVariant1);

                //var byVariant2 = computer.TimeItTakes(() => { new LinkedList<double>().Variant2(i); });
                //timeByVariant2.Add(byVariant2);
                
                var byVariant3 = computer.TimeItTakes(() => { new ArrayList(i).Variant3(); });
                timeByVariant3.Add(byVariant3);
            }

            await new ResultWriter().Write(new List<KeyValuePair<string, List<long>>>()
            {
                KeyValuePair.Create($"{nameof(Task2)} {nameof(timeByVariant1)}, big range", timeByVariant1),
                //KeyValuePair.Create($"{nameof(Task2)} {nameof(timeByVariant2)}", timeByVariant2),
                KeyValuePair.Create($"{nameof(Task2)} {nameof(timeByVariant3)}, big range", timeByVariant3)
            });
        }
    }
}
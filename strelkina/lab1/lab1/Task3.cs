using System.Collections.Generic;
using System.Threading.Tasks;

namespace lab1
{
    public class Task3
    {
        public async Task Execute()
        {
            var var1Result = new List<long>();

            var var2Result = new List<long>();

            var computer = new Computer();
            
            var var1 = computer.TimeItTakes(() => { new HashSet<int>().Variant1(); });
            var1Result.Add(var1);

            var var2 = computer.TimeItTakes(() => { new HashSet<int>().Variant2(); });
            var2Result.Add(var2);
            
            await new ResultWriter().Write(new List<KeyValuePair<string, List<long>>>()
            {
                KeyValuePair.Create($"{nameof(Task3)} {nameof(var1Result)}", var1Result),
                KeyValuePair.Create($"{nameof(Task3)} {nameof(var2Result)}", var2Result)
            });
        }
    }
}

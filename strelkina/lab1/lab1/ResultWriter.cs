using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace lab1
{
    public class ResultWriter
    {
        public async Task Write(List<KeyValuePair<string, List<long>>> sourse)
        {
            for (int i = 0; i < sourse.Count; i++)
            {
                await using var sw1 = new StreamWriter($"./{sourse[i].Key}.txt");
                await sw1.WriteAsync(sourse[i].Value.Select(x => x.ToString()).Aggregate((s1, s2) => s1 + ", " + s2));
            }
        }
    }
}

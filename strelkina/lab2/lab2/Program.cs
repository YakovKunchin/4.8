using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace lab2
{
    class Program
    {
        static void Main()
        {
            var computer = new Computer();
            
            foreach (var num in new List<int> {2, 4, 8, 10})
            {
                var time = computer.TimeItTakes(() =>
                    Parallel.Invoke(new ParallelOptions {MaxDegreeOfParallelism = num},
                        () => new FromWebToLocal().Execute())
                );
                Console.WriteLine($"{nameof(FromWebToLocal)}, MaxDegreeOfParallelism: {num}. Time: {time}.");
            }

            Console.WriteLine();
            
            foreach (var num in new List<int> {2, 4, 8, 10})
            {
                var time = computer.TimeItTakes(() =>
                    Parallel.Invoke(new ParallelOptions {MaxDegreeOfParallelism = num},
                        async () => await new FromLocalToLocal().Execute())
                );
                Console.WriteLine($"{nameof(FromLocalToLocal)}, MaxDegreeOfParallelism: {num}. Time: {time}.");
            }
        }
    }
    
    
    public class FromWebToLocal
    {
        public void Execute()
        {
            var uri = new Uri(@"https://javaconceptoftheday.com/wp-content/uploads/2016/08/NumberPatternPrograms.png");
            
            using var client = new WebClient();
            client.DownloadFileAsync(uri, $"{nameof(Execute)}. NumberPatternPrograms.png");
        }
    }
    
    public class FromLocalToLocal
    {
        public async Task Execute()
        {
            using var sr = new StreamReader("NumberPatternPrograms.png");
            var file = await sr.ReadToEndAsync().ConfigureAwait(false);

            Directory.CreateDirectory("Rewritten");
            await using var sw = new StreamWriter("Rewritten/NumberPatternPrograms.png");
            await sw.WriteAsync(file).ConfigureAwait(false);
        }
    }
}

using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {
        static void Main()
        {
            var computer = new Computer();

            var time = computer.TimeItTakes(() => new FromWebToLocal().OneTask());
            Console.WriteLine(time);
            
            time = computer.TimeItTakes(() => new FromWebToLocal().TwoTasks());
            Console.WriteLine(time);
            
            time = computer.TimeItTakes(() => new FromLocalToLocal().OneTask());
            Console.WriteLine(time);
            
            time = computer.TimeItTakes(async () => await new FromLocalToLocal().TwoTasks());
            Console.WriteLine(time);

            time = computer.TimeItTakes(async () => await new FromLocalToLocal().ThreeTasks());
            Console.WriteLine(time);
            
            time = computer.TimeItTakes(async () => await new FromLocalToLocal().FourTasks());
            Console.WriteLine(time);
            //await FourTasks.Execute().ConfigureAwait(false);
            //await EightTasks.Execute().ConfigureAwait(false);
            //await EightTasks.Execute().ConfigureAwait(false);
            //await TenTasks.Execute().ConfigureAwait(false);
        }
    }

    public class FromWebToLocal
    {
        public void OneTask()
        {
            var uri = new Uri(@"https://javaconceptoftheday.com/wp-content/uploads/2016/08/NumberPatternPrograms.png");
            
            using var client = new WebClient();
            client.DownloadFile(uri, $"{nameof(FromWebToLocal)}. NumberPatternPrograms.png");
        }
        
        public void TwoTasks()
        {
            var uri = new Uri(@"https://javaconceptoftheday.com/wp-content/uploads/2016/08/NumberPatternPrograms.png");
            
            using var client = new WebClient();
            client.DownloadFileAsync(uri, $"{nameof(TwoTasks)}. NumberPatternPrograms.png");
        }
    }
    
    public class FromLocalToLocal
    {
        public void OneTask()
        {
            using var sr = new StreamReader("NumberPatternPrograms.png");
            var file = sr.ReadToEnd();

            Directory.CreateDirectory("Rewritten");
            using var sw = new StreamWriter("Rewritten/NumberPatternPrograms.png");
            sw.Write(file);
        }
        
        public async Task TwoTasks()
        {
            using var sr = new StreamReader("NumberPatternPrograms.png");
            var file = await sr.ReadToEndAsync().ConfigureAwait(false);

            Directory.CreateDirectory("Rewritten");
            using var sw = new StreamWriter("Rewritten/NumberPatternPrograms.png");
            sw.Write(file);
        }
        
        public async Task ThreeTasks()
        {
            using var sr = new StreamReader("NumberPatternPrograms.png");
            var file = await sr.ReadToEndAsync().ConfigureAwait(false);

            Directory.CreateDirectory("Rewritten");
            await using var sw = new StreamWriter("Rewritten/NumberPatternPrograms.png");
            sw.WriteAsync(file);
        }
        
        public async Task FourTasks()
        {
            using var sr = new StreamReader("NumberPatternPrograms.png");
            var file = await sr.ReadToEndAsync().ConfigureAwait(false);

            Directory.CreateDirectory("Rewritten");
            await using var sw = new StreamWriter("Rewritten/NumberPatternPrograms.png");
            await sw.WriteAsync(file).ConfigureAwait(false);
        }
    }
}
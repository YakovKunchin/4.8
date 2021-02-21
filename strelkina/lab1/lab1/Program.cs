using System.Threading.Tasks;

namespace lab1
{
    class Program
    {
        static async Task Main()
        {
            await new Task1().Execute();
            await new Task2().Execute();
            //await new Task3().Execute();
        }
    }
}
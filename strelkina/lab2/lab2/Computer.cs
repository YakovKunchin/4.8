using System;
using System.Diagnostics;

namespace lab2
{
    public class Computer
    {
        public long TimeItTakes(Action action)
        {
            Stopwatch st = new();
            st.Start();
            
            action.Invoke();
            
            st.Stop();

            return st.ElapsedTicks;
        }
    }
}

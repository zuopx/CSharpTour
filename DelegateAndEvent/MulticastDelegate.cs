using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateAndEvent
{
    class MulticastDelegate
    {
        static Action<int> Add = i => i++;
        static Action<int> Print = i => Console.WriteLine(i);
        static Action<int> AddThenPrint = i => { i++; Console.WriteLine(i); };

        static public void run()
        {
            Action<int> all = Add + Print;
            all(1);
            all += Print;
            all(1);

            AddThenPrint(1);

            int a = 1;
            all(a);
            AddThenPrint(a);
        }
    }
}

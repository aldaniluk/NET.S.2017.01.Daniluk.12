using System;
using Logic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            OneCustomer one = new OneCustomer();
            TwoCustomer two = new TwoCustomer();
            CountdownHelper countdown = new CountdownHelper();
            one.Register(countdown);
            countdown.CreateNewCountdown(1_000, "first event!");
            two.Register(countdown);
            countdown.CreateNewCountdown(1_500, "second event!");
            one.Unregister(countdown);

            CountdownHelper countdown2 = new CountdownHelper();
            one.Register(countdown2);

            countdown.CreateNewCountdown(2_000, "third event!");
            countdown2.CreateNewCountdown(0, "fourth event! countdown2!");
        }
    }
}

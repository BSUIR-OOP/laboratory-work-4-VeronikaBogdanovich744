using System;
namespace LR4_main
{
    internal class NumberService:IService
    {
        int random;
        static Random rnd = new Random();
        public NumberService()
        {
            random = rnd.Next(200);
        }

        public void Print()
        {
            Console.WriteLine($"The number is {random}");
        }
    }
}
using System;

namespace Task_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Words words = new Words("оболонь слюна трижды труд знамя моль\nабырвалг тормоза гайдак ойё");
            Console.WriteLine(words.ToString());
            Console.Read();
        }
    }
}

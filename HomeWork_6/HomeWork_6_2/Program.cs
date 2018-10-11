using System;

namespace HomeWork_6_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Bouquet bouquet = new Bouquet();
            Flower rose = new Flower(FlowersName.Rose, Colors.Red, 45.5);
            Flower camomile = new Flower(FlowersName.Camomile, Colors.White, 10);
            Flower carnation = new Flower(FlowersName.Carnation, Colors.Yellow, 16.7);
            Flower tulip = new Flower(FlowersName.Tulip, Colors.Black, 20.4);
            bouquet.AddFlowers(rose, rose, rose, tulip, carnation, carnation, camomile);
            Console.WriteLine("cost" + bouquet.Cost);
            Console.Read();
        }
    }
}

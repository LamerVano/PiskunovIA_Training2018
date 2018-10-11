using System.Collections.Generic;

namespace HomeWork_6_2
{
    class Bouquet
    {
        private List<Flower> _bouquet;


        public double Cost
        {
            get
            {
                double cost = 0;
                foreach(Flower i in _bouquet)
                {
                    cost += i.Cost;
                }
                return cost;
            }
        }

        public Bouquet(List<Flower> flowers)
        {
            _bouquet = new List<Flower>();
            _bouquet.AddRange(flowers);
        }

        public Bouquet()
        {
            _bouquet = new List<Flower>();
        }

        public void AddFlower(Flower flower)
        {
            _bouquet.Add(flower);
        }

        public void AddFlowers(params Flower[] flowers)
        {
            _bouquet.AddRange(flowers);
        }
    }
}

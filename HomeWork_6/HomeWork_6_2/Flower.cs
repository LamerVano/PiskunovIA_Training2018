namespace HomeWork_6_2
{
    class Flower
    {
        private double _cost;

        public Colors Color { get; private set; }
        public double Cost
        {
            get
            {
                return _cost;
            }
            set
            {
                if(value > 0)
                {
                    _cost = value;
                }
            }

        }
        public FlowersName Name { get; private set; }
        
        public Flower(FlowersName name, Colors color)
        {
            Name = name;
            Color = color;
            Cost = 1;
        }
        public Flower(FlowersName name, Colors color, double cost)
        {
            Name = name;
            Color = color;
            Cost = cost;
        }
    }
}

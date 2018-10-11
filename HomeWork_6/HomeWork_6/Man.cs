namespace HomeWork_6
{
    class Man
    {
        private int _age;
        private Gender _gender;
        private double _weight;

        public int Age
        {
            get
            {
                return _age;
            }
        }

        public Gender GenderMan
        {
            get
            {
                return _gender;
            }
        }

        public double Weight
        {
            get
            {
                return _weight;
            }
        }

        public Man(int age, Gender gender, double weight)
        {
            _age = age;
            _gender = gender;
            _weight = weight;
        }

        public void Birthday()
        {
            _age++;
        }

        public void ChangeWeight(double weight)
        {
            _weight = weight;
        }
    }
}

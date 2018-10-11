namespace HomeWork_6
{
    class Student: Man
    {
        private int _year;

        public Student(Man man): this(man, 1)
        {
        }

        public Student(Man man, int year): base(man.Age, man.GenderMan, man.Weight)
        {
            _year = year;
        }

        public void ChangeYear(int year)
        {
            _year = year;
        }

        public void IncreaseYear()
        {
            _year++;
        }
    }
}

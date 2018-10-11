namespace HomeWork_6
{
    class Teacher: Man
    {
        private Subjects _subject;

        public Teacher(Man man, Subjects subject): base(man.Age, man.GenderMan, man.Weight)
        {
            _subject = subject;
        }

        public void ChangeSubject(Subjects newSubject)
        {
            _subject = newSubject;
        }
    }
}

namespace Task_8
{
    class Words
    {
        private Word[] _words;

        public Words(string str)
        {
            string[] words = str.Split(' ');
            int lenght = words.Length;
            _words = new Word[lenght];
            for(int i = 0; i < lenght; i++)
            {
                _words[i] = new Word(words[i]);
            }
        }

        public override string ToString()
        {
            string str = "";

            foreach(Word word in _words)
            {
                str += word.ToString() + " ";
            }

            return str;
        }
    }
}

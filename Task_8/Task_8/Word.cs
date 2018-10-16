using System.Linq;
using System.Text;

namespace Task_8
{
    class Word
    {
        private string _word;
        private StringBuilder _divideWord;

        public Word(string word)
        {
            _word = word;
        }

        public override string ToString()
        {
            if(_divideWord != null)
            {
                return _divideWord.ToString();
            }
            else
            {
                return DivideBySyllables();
            }
        }

        private string DivideBySyllables()
        {
            _divideWord = new StringBuilder(_word);

            char[] vowel = { 'а', 'е', 'ё', 'у', 'ы', 'о', 'э', 'я', 'и', 'ю' };
            char[] consonant = { 'й', 'ц', 'к', 'н', 'г', 'ш', 'щ', 'з', 'х', 'ф', 'в', 'п', 'р', 'л', 'д', 'ж', 'ч', 'с', 'м', 'т', 'б' };

            int lenght = _word.Length;
            int numHyphen = 0;
            for(int i = 0; i < lenght - 1; i++)
            {
                if(vowel.Contains(_word[i]))
                {
                    if(vowel.Contains(_word[i + 1]))
                    {
                        AddHyphen(i + 1 + numHyphen);
                        i++;
                        numHyphen++;
                    }
                    else if(_word[i + 1] == 'й')
                    {
                        AddHyphen(i + 2 + numHyphen);
                        i++;
                        numHyphen++;
                    }
                    else if(consonant.Contains(_word[i + 1]))
                    {
                        if (i + 2 >= lenght)
                        {
                            break;
                        }
                        else if (vowel.Contains(_word[i + 2]))
                        {
                            AddHyphen(i + 1 + numHyphen);
                            numHyphen++;
                            i++;
                        }
                        else if (consonant.Contains(_word[i + 2]))
                        {
                            for(int j = 3; j < lenght - i; j++)
                            { 
                                if (vowel.Contains(_word[i + j]))
                                {
                                    AddHyphen(i + 2 + numHyphen);
                                    numHyphen++;
                                    i++;
                                    break;
                                }
                            }
                        }
                        else if (_word[i + 2] == 'ь' || _word[i + 2] == 'ъ')
                        {
                            if (i + 3 < lenght)
                            {
                                if (vowel.Contains(_word[i + 3]) || consonant.Contains(_word[i + 3]))
                                {
                                    AddHyphen(i + 3 + numHyphen);
                                    numHyphen++;
                                    i = i + 2;
                                }
                            }
                        }
                    }
                }
            }

            return _divideWord.ToString();
        }

        private void AddHyphen(int index)
        {
            if (index < _divideWord.Length)
            {
                _divideWord.Insert(index, '-');
            }
        }
    }
}

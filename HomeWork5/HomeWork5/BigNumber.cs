using System;
using System.Collections.Generic;

namespace HomeWork5
{
    class BigNumber
    {
        private bool _isSigned = false;
        private int[] _number;

        public int[] Number
        {
            get
            {
                return _number;
            }
            set
            {
                _number = ConvertToArray(value);
            }
        }
        public bool IsSigned
        {
            get
            {
                return _isSigned;
            }
            set
            {
                _isSigned = value;
            }
        }

        public static BigNumber CalcFactorial(int n)
        {
            int[] facktorial = new int[1] { 1 };
            for (int i = 1; i <= n; i++)
            {
                facktorial = MultiplyAbs(facktorial, ConvertToArray(i));
            }
            int[] num = DelZero(facktorial);
            return new BigNumber(num, false);
        }

        public BigNumber(int[] num, bool isSigned)
        {
            IsSigned = isSigned;
            _number = num;
        }

        public BigNumber(int num)
        {
            if(num < 0)
            {
                IsSigned = true;
            }
            _number = ConvertToArray(Math.Abs(num));
        }

        public BigNumber(byte num)
        {
            if (num < 0)
            {
                IsSigned = true;
            }
            _number = ConvertToArray(Math.Abs(num));
        }

        public BigNumber(long num)
        {
            if (num < 0)
            {
                IsSigned = true;
            }
            _number = ConvertToArray(Math.Abs(num));
        }

        public BigNumber(string num)
        {
            if (num[0] == '-')
            {
                IsSigned = true;
                num.Remove(0, 1);
            }
            _number = ConvertToArray(num);
        }

        private static int[] DelZero(int[] num)
        {
            List<int> now = new List<int>();
            int len = num.Length;
            for (int i = 0; i < len; i++)
            {
                if (now.Count == 0 & num[i] == 0)
                {
                    continue;
                }
                else
                {
                    now.Add(num[i]);
                }
            }
            return now.ToArray();
        }

        private static int[] ConvertToArray(int[] num)
        {
            return num;
        }

        private static int[] ConvertToArray(int num)
        {
            List<int> ret = new List<int>();
            string str = "" + num;
            for (int i = 0; i < str.Length; i++)
            {
                ret.Add(str[i] - 48);
            }
            return ret.ToArray();
        }

        private static int[] ConvertToArray(long num)
        {
            List<int> ret = new List<int>();
            string str = "" + num;
            for (int i = 0; i < str.Length; i++)
            {
                ret.Add(str[i] - 48);
            }
            return ret.ToArray();
        }

        private static int[] ConvertToArray(byte num)
        {
            List<int> ret = new List<int>();
            string str = "" + num;
            for (int i = 0; i < str.Length; i++)
            {
                ret.Add(str[i] - 48);
            }
            return ret.ToArray();
        }

        private static int[] ConvertToArray(string num)
        {
            List<int> ret = new List<int>();
            for (int i = 0; i < num.Length; i++)
            {
                ret.Add(num[i] - 48);
            }
            return ret.ToArray();
        }

        public static BigNumber ConvertToBigNumber(int num)
        {
            BigNumber number = new BigNumber(num);
            return number;
        }

        public static BigNumber ConvertToBigNumber(byte num)
        {
            BigNumber number = new BigNumber(num);
            return number;
        }

        public static BigNumber ConvertToBigNumber(long num)
        {
            BigNumber number = new BigNumber(num);
            return number;
        }

        public static BigNumber ConvertToBigNumber(int[] num)
        {
            BigNumber number = new BigNumber(num, false);
            return number;
        }

        public static BigNumber ConvertToBigNumber(string num)
        {
            BigNumber number = new BigNumber(num);
            return number;
        }

        public BigNumber Sum(BigNumber bigNumber)
        {
            return Sum(bigNumber, this);
        }

        public BigNumber Sum(int num)
        {
            return Sum(new BigNumber(num), this);
        }

        public BigNumber Sum(byte num)
        {
            return Sum(new BigNumber(num), this);
        }

        public BigNumber Sum(long num)
        {
            return Sum(new BigNumber(num), this);
        }

        public BigNumber Sum(int[] num)
        {
            return Sum(new BigNumber(num, false), this);
        }

        public BigNumber Sum(string num)
        {
            return Sum(new BigNumber(num), this);
        }

        public static BigNumber Sum(int num1, int num2)
        {
            return Sum(new BigNumber(num1), new BigNumber(num2));
        }

        public static BigNumber Sum(byte num1, byte num2)
        {
            return Sum(new BigNumber(num1), new BigNumber(num2));
        }

        public static BigNumber Sum(long num1, long num2)
        {
            return Sum(new BigNumber(num1), new BigNumber(num2));
        }

        public static BigNumber Sum(int[] num1, int[] num2)
        {
            return Sum(new BigNumber(num1, false), new BigNumber(num2, false));
        }

        public static BigNumber Sum(string num1, string num2)
        {
            return Sum(new BigNumber(num1), new BigNumber(num2));
        }

        private static int[] ToSignedArray(int[] num)
        {
            int lenght = num.Length;
            for(int i = 0; i < lenght; i++)
            {
                num[i] = -num[i]; 
            }
            return num;
        }

        public static BigNumber Sum(BigNumber bigNumber1, BigNumber bigNumber2)
        {
            int[] resultNum;
            bool resultSign = false;

            if (IsGreater(bigNumber1, bigNumber2))
            {
                if(bigNumber1.IsSigned)
                {
                    if (!bigNumber2.IsSigned)
                    {
                        resultNum = SubtractionAbs(bigNumber1.Number, bigNumber2.Number);
                    }
                    else
                    {
                        resultNum = SumAbs(bigNumber1.Number, bigNumber2.Number);
                    }
                    resultSign = true;
                }
                else if(bigNumber2.IsSigned)
                {
                    resultNum = SubtractionAbs(bigNumber1.Number, bigNumber2.Number);
                }
                else
                {
                    resultNum = SumAbs(bigNumber1.Number, bigNumber2.Number);
                }
            }
            else if(IsGreater(bigNumber2, bigNumber1))
            {
                if (bigNumber2.IsSigned)
                {
                    if (!bigNumber1.IsSigned)
                    {
                        resultNum = SubtractionAbs(bigNumber2.Number, bigNumber1.Number);
                    }
                    else
                    {
                        resultNum = SumAbs(bigNumber2.Number, bigNumber1.Number);
                    }
                    resultSign = true;
                }
                else if (bigNumber1.IsSigned)
                {
                    resultNum = SubtractionAbs(bigNumber2.Number, bigNumber1.Number);
                }
                else
                {
                    resultNum = SumAbs(bigNumber1.Number, bigNumber2.Number);
                }
            }
            else
            {
                resultNum = SumAbs(bigNumber1.Number, bigNumber2.Number);
            }
            
            return new BigNumber(resultNum, resultSign);
        }

        private static int[] SumAbs(int[] num1, int[] num2)
        {
            int lenght1 = num1.Length, lenght2 = num2.Length;
            int maxLenght;

            if(lenght1 > lenght2)
            {
                maxLenght = lenght1 + 1;
            }
            else
            {
                maxLenght = lenght2 + 1;
            }

            int[] resultNum = new int[maxLenght];
            resultNum[0] = 0;
            for (int i = maxLenght - 1, j = lenght1 - 1, t = lenght2 - 1; i >= 0; i--, j--, t--)
            {
                if (j >= 0 & t >= 0)
                {
                    resultNum[i] = num1[j] + num2[t];
                }
                else if (j >= 0 & t < 0)
                {
                    resultNum[i] = num1[j];
                }
                else if (t >= 0 & j < 0)
                {
                    resultNum[i] = num2[t];
                }
            }
            resultNum = ToCorrectNum(resultNum);
            resultNum = DelZero(resultNum);
            return resultNum;
        }

        private static int[] SubtractionAbs(int[] num1, int[] num2)
        {
            int lenght1 = num1.Length, lenght2 = num2.Length;

            int[] resultNum = new int[lenght1];
            resultNum[0] = 0;
            for (int i = lenght1 - 1, j = lenght2 - 1; i >= 0; i--, j--)
            {
                if (j >= 0)
                {
                    resultNum[i] = num1[i] - num2[j];
                }
                else if (j < 0)
                {
                    resultNum[i] = num1[i];
                }
            }
            resultNum = ToCorrectNum(resultNum);
            resultNum = DelZero(resultNum);
            return resultNum;
        }

        public static BigNumber Subtraction(BigNumber bigNumber1, BigNumber bigNumber2)
        {
            int[] resultNum;
            bool resultSign = false;

            if (IsGreater(bigNumber1, bigNumber2))
            {
                if (bigNumber1.IsSigned)
                {
                    if (!bigNumber2.IsSigned)
                    {
                        resultNum = SumAbs(bigNumber1.Number, bigNumber2.Number);
                    }
                    else
                    {
                        resultNum = SubtractionAbs(bigNumber1.Number, bigNumber2.Number);
                    }
                    resultSign = true;
                }
                else if (bigNumber2.IsSigned)
                {
                    resultNum = SumAbs(bigNumber1.Number, bigNumber2.Number);
                }
                else
                {
                    resultNum = SubtractionAbs(bigNumber1.Number, bigNumber2.Number);
                }
            }
            else if (IsGreater(bigNumber2, bigNumber1))
            {
                if (bigNumber2.IsSigned)
                {
                    if (!bigNumber1.IsSigned)
                    {
                        resultNum = SumAbs(bigNumber2.Number, bigNumber1.Number);
                    }
                    else
                    {
                        resultNum = SubtractionAbs(bigNumber2.Number, bigNumber1.Number);
                    }
                }
                else if (bigNumber1.IsSigned)
                {
                    resultNum = SumAbs(bigNumber2.Number, bigNumber1.Number);
                    resultSign = true;
                }
                else
                {
                    resultNum = SubtractionAbs(bigNumber2.Number, bigNumber1.Number);
                    resultSign = true;
                }
            }
            else
            {
                resultNum = new int[1] { 0 };
            }

            return new BigNumber(resultNum, resultSign);
        }

        public static BigNumber Subtraction(byte num1, byte num2)
        {
            return Subtraction(new BigNumber(num1), new BigNumber(num1));
        }

        public static BigNumber Subtraction(int num1, int num2)
        {
            return Subtraction(new BigNumber(num1), new BigNumber(num1));
        }

        public static BigNumber Subtraction(long num1, long num2)
        {
            return Subtraction(new BigNumber(num1), new BigNumber(num1));
        }

        public static BigNumber Subtraction(int[] num1, int[] num2)
        {
            return Subtraction(new BigNumber(num1, false), new BigNumber(num1, false));
        }

        public static BigNumber Subtraction(string num1, string num2)
        {
            return Subtraction(new BigNumber(num1), new BigNumber(num1));
        }

        public BigNumber Subtraction(BigNumber bigNumber)
        {
            return Subtraction(this, bigNumber);
        }

        public BigNumber Subtraction(byte num)
        {
            return Subtraction(this, new BigNumber(num));
        }

        public BigNumber Subtraction(int num)
        {
            return Subtraction(this, new BigNumber(num));
        }

        public BigNumber Subtraction(long num)
        {
            return Subtraction(this, new BigNumber(num));
        }

        public BigNumber Subtraction(int[] num)
        {
            return Subtraction(this, new BigNumber(num, false));
        }

        public BigNumber Subtraction(string num)
        {
            return Subtraction(this, new BigNumber(num));
        }

        private static int[] ToCorrectNum(int[] num)
        {
            while (!IsCorrect(num))
            {
                for (int i = 0; i < num.Length - 1; i++)
                {
                    num[i] += num[i + 1] / 10;
                    num[i + 1] -= (num[i + 1] / 10) * 10;
                    if (num[i + 1] < 0)
                    {
                        num[i + 1] += 10;
                        num[i] -= 1;
                    }
                }
            }
            return num;
        }

        public BigNumber Multiply(BigNumber bigNumber)
        {
            return Multiply(bigNumber, this);
        }

        public BigNumber Multiply(int num)
        {
            return Multiply(new BigNumber(num), this);
        }

        public BigNumber Multiply(byte num)
        {
            return Multiply(new BigNumber(num), this);
        }

        public BigNumber Multiply(long num)
        {
            return Multiply(new BigNumber(num), this);
        }

        public BigNumber Multiply(int[] num, bool isSigned)
        {
            return Multiply(new BigNumber(num, isSigned), this);
        }

        public BigNumber Multiply(string num)
        {
            return Multiply(new BigNumber(num), this);
        }

        public static BigNumber Multiply(BigNumber bigNumber1, BigNumber bigNumber2)
        {
            int[] num1 = bigNumber1.Number;
            int[] num2 = bigNumber2.Number;
            
            return new BigNumber(MultiplyAbs(num1, num2), bigNumber1.IsSigned ^ bigNumber2.IsSigned);
        }

        private static int[] MultiplyAbs(int[] num1, int[] num2)
        {
            int lenght1 = num1.Length, lenght2 = num2.Length;
            int[][] sums = new int[lenght2][];
            for (int i = 0; i < lenght2; i++)
            {
                sums[i] = new int[lenght1];
                for (int j = 0; j < lenght1; j++)
                {
                    sums[i][j] = num2[i] * num1[j];
                }
            }
            int[] resultNum = new int[lenght1 + lenght2];
            resultNum[0] = 0;
            for (int i = 0; i < lenght2; i++)
            {
                for (int j = 0; j < lenght1; j++)
                {
                    resultNum[i + j + 1] += sums[i][j];
                }
            }
            resultNum = ToCorrectNum(resultNum);
            resultNum = DelZero(resultNum);
            return resultNum;
        }

        private static bool IsCorrect(int[] ret)
        {
            foreach (int i in ret)
            {
                if (i / 10 != 0)
                {
                    return false;
                }
                else if(i < 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsGreater(BigNumber bigNumber1, BigNumber bigNumber2)
        {
            int[] num1 = bigNumber1.Number;
            int[] num2 = bigNumber2.Number;
            int lenght1 = num1.Length, lenght2 = num2.Length;
            if (lenght1 > lenght2)
            {
                return true;
            }
            else if (lenght1 < lenght2)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < lenght1; i++)
                {
                    if (num1[i] > num2[i])
                    {
                        return true;
                    }
                    else if (num1[i] < num2[i])
                    {
                        return false;
                    }
                }
                return false;
            }
        }

        public override string ToString()
        {
            string str = "";
            if(IsSigned)
            {
                str += "-";
            }
            int lenght = _number.Length;
            for(int i = 0; i < lenght; i++)
            {
                str += _number[i];
            }
            return str;
        }
    }
}

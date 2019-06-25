using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        public static int GetDivision(String number, String result)  {
            int num = int.Parse(result)/int.Parse(number);
            int rem = int.Parse(result)%int.Parse(number);
            if(rem != 0)
                return -1;
            else
                return num;
        }

        public static int GetProduct(String A, String B)  {
            int result = int.Parse(A) * int.Parse(B);
            return result;
        }

        public static int CheckExpected(int number, String providedNumber)  {
            String evaluatedValue = number.ToString();
            int indexOfQMARK = providedNumber.IndexOf('?');
            providedNumber =  providedNumber.Remove(indexOfQMARK,1);
            int valueOfQmark = int.Parse(evaluatedValue[indexOfQMARK].ToString());
            evaluatedValue = evaluatedValue.Remove(indexOfQMARK, 1);
            if(providedNumber == evaluatedValue)
                return valueOfQmark;
            else
                return -1;
        }

        private static void Test(string args, int expected)  {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }
        public static int FindDigit(string equation)  {
            int indexOfAstrik = equation.IndexOf('*');
            int indexOfEquals = equation.IndexOf('=');
            String A = equation.Substring(0,indexOfAstrik);
            String B = equation.Substring(indexOfAstrik+1, indexOfEquals-indexOfAstrik-1);
            String C = equation.Substring(indexOfEquals+1);
            int checkResult = 0;

            if(C.Contains('?'))  {
                int c = GetProduct(A, B);
                checkResult = CheckExpected(c, C);
            }
            else  {
                int resNumber;
                if(A.Contains('?'))  {
                    resNumber = GetDivision(B, C);
                    if(resNumber != -1)
                        checkResult = CheckExpected(resNumber, A);
                    else 
                        checkResult = -1;
                }
                else  {
                    resNumber = GetDivision(A, C);
                    if(resNumber != -1)
                        checkResult = CheckExpected(resNumber, B);
                    else
                        checkResult = -1;
                }
            }

            return checkResult;
        }
    }
}
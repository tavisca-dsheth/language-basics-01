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

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }
        public static int FindDigit(string equation)
        {
            int index = equation.IndexOf('*');
            String a = equation.Substring(0,index);

            int index1 = equation.IndexOf('=');
            String b = equation.Substring(index+1,index1-index-1);

            String c = equation.Substring(index1+1);

            if(a.Contains('?'))  {
                float num2 = float.Parse(b);
                float res = float.Parse(c);

                float num1 = res/num2;

                String result = num1.ToString();

                char[] a1 = a.ToCharArray();
                char[] res1 = result.ToCharArray();

                if(a1.Length == res1.Length)  {
                    int i = 0, num = -1;
                    while(i<a1.Length)  {
                        if(a1[i] == '?')  {
                            num = int.Parse(res1[i].ToString());
                            i++;
                        }
                        else if(a1[i] == res1[i])  {
                            i++;
                        }
                        else
                            break;
                    }
                    if(i == a1.Length)
                        return num;
                    else
                        return -1;
                }
                else
                    return -1;
            }

            else if(b.Contains('?'))  {
                float num1 = float.Parse(a);
                float res = float.Parse(c);

                float num2 = res/num1;

                String result = num2.ToString();

                char[] b1 = b.ToCharArray();
                char[] res1 = result.ToCharArray();

                if(b1.Length == res1.Length)  {
                    int i = 0, num = -1;
                    while(i<b1.Length)  {
                        if(b1[i] == '?')  {
                            num = int.Parse(res1[i].ToString());
                            i++;
                        }
                        else if(b1[i] == res1[i])  {
                            i++;
                        }
                        else
                            break;
                    }
                    if(i == b1.Length)
                        return num;
                    else
                        return -1;
                }
                else
                    return -1;
            }

            else  {
                float num1 = float.Parse(a);
                float num2 = float.Parse(b);

                float res = num1 * num2;

                String result = res.ToString();

                char[] c1 = c.ToCharArray();
                char[] res1 = result.ToCharArray();

                if(c1.Length == res1.Length)  {
                    int i = 0, num = -1;
                    while(i<c1.Length)  {
                        if(c1[i] == '?')  {
                            num = int.Parse(res1[i].ToString());
                            i++;
                        }
                        else if(c1[i] == res1[i])
                            i++;
                        else
                            break;
                    }
                    if(i == c1.Length)
                        return num;
                    else
                        return -1;
                }
                else
                    return -1;
            }
            //Add your code here.
            //throw new NotImplementedException();
        }
    }
}

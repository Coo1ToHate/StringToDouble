using System;

namespace ToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "     -9876 543210,1234567890 1234567890";
            string s2 = "9876543210  ,1234567890 1234567890";
            string s3 = "5,1234567890 1234657980 1234567980   ";
            string s4 = " -65446598 7653219876,486798654";
            string s5 = "-6,1234567890123456789054465 9999999998999999999999999999999999999999999999999999999999999";

            Console.WriteLine(s);
            Console.WriteLine($">>> {StringToDouble(s)}");
            Console.WriteLine($"!!! {double.Parse(FormatString(s))}");
            Console.WriteLine();

            Console.WriteLine(s2);
            Console.WriteLine($">>> {StringToDouble(s2)}");
            Console.WriteLine($"!!! {double.Parse(FormatString(s2))}");
            Console.WriteLine();

            Console.WriteLine(s3);
            Console.WriteLine($">>> {StringToDouble(s3)}");
            Console.WriteLine($"!!! {double.Parse(FormatString(s3))}");
            Console.WriteLine();

            Console.WriteLine(s4);
            Console.WriteLine($">>> {StringToDouble(s4)}");
            Console.WriteLine($"!!! {double.Parse(FormatString(s4))}");
            Console.WriteLine();

            Console.WriteLine(s5);
            Console.WriteLine($">>> {StringToDouble(s5)}");
            Console.WriteLine($"!!! {double.Parse(FormatString(s5))}");
            Console.WriteLine();
        }

        private static double StringToDouble(string str)
        {
            double resultW = 0;
            double resultF = 0;
            bool negative = false;

            str = str.Trim();
            str = str.Replace(" ", "");

            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException();
            }

            str = str.Replace('.', ',');

            var strs = str.Split(',');

            if (strs.Length > 2)
            {
                throw new ArgumentException();
            }

            double rank = 1.0;

            for (int i = strs[0].Length - 1; i >= 0; i--)
            {
                switch (strs[0][i])
                {
                    case '-':
                        if (i == 0)
                        {
                            resultW *= -1;
                            negative = true;
                        }
                        else
                        {
                            throw new ArgumentException();
                        }
                        break;
                    case '0':
                        resultW += 0 * rank;
                        break;
                    case '1':
                        resultW += 1 * rank;
                        break;
                    case '2':
                        resultW += 2 * rank;
                        break;
                    case '3':
                        resultW += 3 * rank;
                        break;
                    case '4':
                        resultW += 4 * rank;
                        break;
                    case '5':
                        resultW += 5 * rank;
                        break;
                    case '6':
                        resultW += 6 * rank;
                        break;
                    case '7':
                        resultW += 7 * rank;
                        break;
                    case '8':
                        resultW += 8 * rank;
                        break;
                    case '9':
                        resultW += 9 * rank;
                        break;
                    default:
                        throw new ArgumentException();
                }
                rank *= 10;
            }


            if (strs.Length == 2)
            {
                bool flag = false;

                if (strs[1].Length > 15)
                {
                    strs[1] = strs[1].Substring(0, 15);
                }

                rank = 0.1;

                for (int i = 0; i < strs[1].Length; i++)
                {
                    switch (strs[1][i])
                    {
                        case '0':
                            resultF += 0 * rank;
                            break;
                        case '1':
                            resultF += 1 * rank;
                            break;
                        case '2':
                            resultF += 2 * rank;
                            break;
                        case '3':
                            resultF += 3 * rank;
                            break;
                        case '4':
                            resultF += 4 * rank;
                            break;
                        case '5':
                            resultF += 5 * rank;
                            break;
                        case '6':
                            resultF += 6 * rank;
                            break;
                        case '7':
                            resultF += 7 * rank;
                            break;
                        case '8':
                            resultF += 8 * rank;
                            break;
                        case '9':
                            resultF += 9 * rank;
                            break;
                        default:
                            throw new ArgumentException();
                    }
                    rank /= 10;
                }
            }

            return negative ? resultW - resultF : resultW + resultF;
        }

        private static string FormatString(string str)
        {
            str = str.Trim();
            str = str.Replace(" ", "");
            str = str.Replace('.', ',');
            return str;
        }
    }
}

using List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace List
{
    static class StatisticOperation
    {
        public static int Sum(this LinkedList<string> list)
        {
            int sum = 0;
            string test = list.ToString();
            var strArr = test.Split(" ");
            for (int i = 0; i < strArr.Count(); i++)
            {
                int len = strArr[i].Length;
                sum = sum + len;
            }

            return sum + 1;
        }

        public static int Difference(this LinkedList<string> list)
        {
            string test = list.ToString();
            var strArr = test.Split(" ");

            return strArr.Max().Length - strArr.Min().Length;
        }
        public static int CountOfS(this LinkedList<string> list)
        {
            string test = list.ToString();
            var strArr = test.Split(" ");
            return strArr.Count();
        }
        public static string CutStr(this string str, int len)
        {
            str.Substring(len);
            return str;
        }

    }
}

using System.Linq;
using System.Runtime.CompilerServices;

namespace List
{
    static class ListMethods
    {
        public static int MaxLength(this LinkedList<string> list)
        {
            string test = list.ToString();
            var strArr = test.Split(" ");
            return strArr.Max().Length;
        }

        public static LinkedList<string> RemoveLast(this LinkedList<string> list)
        {
            return list >> list.Count -1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB014
{
    [Serializable]
   public class MyClass
    {
        [NonSerialized]
        public int age;

        public string Name;

        public override string ToString()
        {
            return "Age: " + age + "Name" + Name;
        }
    }
}

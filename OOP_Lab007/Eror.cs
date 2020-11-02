using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab007
{
    public class InvalidData : DivideByZeroException
    {
        public InvalidData(string name) : base(name)
        {
          
        }
    }
    public class InvalidNull : Exception
    {
        public InvalidNull(string massage) :base(massage)
        {

        }
    }
    public class InvalidExepception : ArgumentException
    {
        public int Value { get; }
        public string mas { get; }
        public InvalidExepception(string massage, int val) :base(massage)
        {
            Value = val;
            mas = massage;
        }
    }
}

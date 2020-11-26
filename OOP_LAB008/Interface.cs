using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_LAB008
{
    public interface IAccount<T>
    {
        void Add(T item);
        bool Remove(T item);

        void View();
    }
}

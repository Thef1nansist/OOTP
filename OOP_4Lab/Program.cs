using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace List
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public Node(T data, Node<T> next)
        {
            Data = data;
            Next = next;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }

    public class LinkedList<T> : IEnumerable<T> // односвязный список
    {
        Node<T> head;
        Node<T> tail;
        int count = 0; // кол-во элементов в списке

        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
            if (head == null)
                head = node;
            else tail.Next = node;
            tail = node;
            count++;
        }
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        public bool Equals([AllowNull] T other)
        {
            throw new NotImplementedException();
        }
        public static LinkedList<T> operator +(LinkedList<T> A, LinkedList<T> B)
        {
            LinkedList<T> list = new LinkedList<T>();

            for (Node<T> p = A.head; p != null; p = p.Next)
                list.AddBack(p.Data);
            for (Node<T> p = B.head; p != null; p = p.Next)
                list.AddBack(p.Data);
            return list;
        }
        public static LinkedList<T> operator >>(LinkedList<T> list, int index)
        {

            Node<T> current = list.head;
            Node<T> previous = null;
            var i = 0;

            while (current != null)
            {
                if (i == index)
                {
                    // Если узел в середине или в конце
                    if (previous != null)
                    {
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;

                        // Если current.Next не установлен, значит узел последний,
                        // изменяем переменную tail
                        if (current.Next == null)
                            list.tail = previous;
                    }
                    else
                    {
                        // если удаляется первый элемент
                        // переустанавливаем значение head
                        list.head = list.head.Next;

                        // если после удаления список пуст, сбрасываем tail
                        if (list.head == null)
                            list.tail = null;
                    }
                    list.count--;
                }
                i++;
                previous = current;
                current = current.Next;
            }
            return list;
        }

        public static bool operator !=(LinkedList<T> A, LinkedList<T> B)
        {
            return A.ToString() != B.ToString();   
        }
        public static bool operator ==(LinkedList<T> A, LinkedList<T> B)
        {
            return A.ToString() == B.ToString();
        }

        public override string ToString()
        {
            var res = "";
            for(Node<T> pA = head; pA != null; pA = pA.Next)
            {
                res += pA.Data + " ";
            }
            return res;
        }


        private Node<T> _tail = null;
        public void AddBack(T data)
        {
            if (head == null)
            {
                head = new Node<T>(data, null);
                _tail = head;
            }

            else
            {
                _tail.Next = new Node<T>(data, null);
                _tail = _tail.Next;
            }

            ++count;
        }

        private void AddFront(T data)
        {
            if (head == null)
            {
                head = new Node<T>(data, null);
                tail = head;
            }

            else
            {
                var new_node = new Node<T>(data, head);
                head = new_node;
            }

            ++count;
        }

        public void Insert(int index, T data)
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException();

            if (index == 0)
            {
                AddFront(data);
            }

            else
            {
                Node<T> r = head;

                for (int i = 1; i < index; ++i)
                    r = r.Next;

                Node<T> new_node = new Node<T>(data, r.Next);
                r.Next = new_node;

                ++count;
            }
        }

        public class Owner
        {
            string id;
            string name;
            string edition;

            public Owner(string _ID, string _NAME, string _EDITION)
            {
                id = _ID;
                name = _NAME;
                edition = _EDITION;
            }
        }
        public class Date
        {
            DateTime time = new DateTime();

            public DateTime Time { get { return time; } set { this.time = value; } }
            public Date(DateTime time)
            {
                if (time != null)

                    this.time = time;
                else
                    this.time = DateTime.Now;
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {

            LinkedList<string> A = new LinkedList<string>();
            LinkedList<string> B = new LinkedList<string>();

            A.Add("prif");
            B.Add("poka");

            var pr = A + B;
            foreach(var ap in pr)
            {
                Console.WriteLine(ap);
            }

            A.Add("sdfdsf");
            A.Add("pkoaksdp");
            A.Add("sdfdsasdfbhsf");
            A = A >> 1;
            foreach (var ap in A)
            {
                Console.WriteLine(ap);
            }

            var pk = A == B;
            Console.WriteLine(pk);

            Console.WriteLine(A.MaxLength());

            A = A.RemoveLast();
            Console.WriteLine(A.ToString());

            var summa = A.Sum();
            Console.WriteLine(summa);

            var difference = A.Difference();
            Console.WriteLine(difference);

            A.Add("q");
            A.Add("w");
            A.Add("e");
            A.Add("r");
            A.Add("t");
            A.Add("y");
            A.Add("u");

            var _count = A.CountOfS();
            Console.WriteLine(_count);
        }
    }
}

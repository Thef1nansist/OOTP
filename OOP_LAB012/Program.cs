using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB012
{
    public interface Show
    {
        void Show();
    }
    public class pricol : Show
    {
        public string name;
        public pricol() { }
        public pricol(string name)
        {
            this.name = name;
        }
        void Show.Show()
        {
            Console.WriteLine(name);
        }
        public void Toconsole(List<string> vs)
        {
            foreach (string str in vs) Console.WriteLine(str);
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public override string ToString()
        {
            return "Test last task, My name - " + name;
        }


    }
    static class Reflector
    {
       static public void GetName(string obj)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetType(obj);
            Assembly assembly1 = type.Assembly;
            
            Console.WriteLine($" Name:{assembly1.FullName}\n CodeBase{assembly1.CodeBase} \n");
        }
        static public void GetConstructors(string obj)
        {
            ConstructorInfo[] constructorInfo = Type.GetType(obj).GetConstructors();
            if(constructorInfo.Length>1) Console.WriteLine("Конструкторы есть!\n"); else Console.WriteLine("Конструкторов нет(\n");
        }
        static public void GetMethod(string obj)
        {
            Type type = Type.GetType(obj);
            foreach(MethodInfo methodInfo in type.GetMethods()) Console.WriteLine(methodInfo.Name); Console.WriteLine("\n");
            
        }
        static public void GetField(string obj)
        {
            Type type = Type.GetType(obj);

            foreach(FieldInfo fieldInfo in type.GetFields()) Console.WriteLine(fieldInfo); Console.WriteLine("\n");
            foreach (PropertyInfo propertyInfo in type.GetProperties()) Console.WriteLine(propertyInfo);
        }
        static public void GetInterfece(string obj)
        {
            Type type = Type.GetType(obj);

            foreach (Type interfaceMapping in type.GetInterfaces()) Console.WriteLine(interfaceMapping);

        }
        static public void MethodForType(string obj, string parametr)
        {
            Type type = Type.GetType(obj);
            MethodInfo[] methodInfo = type.GetMethods();
            Console.WriteLine($"Метод из класса: {obj} с параметрами :{parametr}");
            for (int i = 0; i < methodInfo.Length; i++)
            {
               ParameterInfo[] param = methodInfo[i].GetParameters();
                for (int j = 0; j < param.Length; j++)
                {
                    if (parametr == param[j].ParameterType.Name) Console.WriteLine(methodInfo[i].Name);
                }
            }
        }
        static public void Voke(string classname, string methode)
        {
            Type type = Type.GetType(classname);
            List<string> list = File.ReadAllLines("D:\\UN\\OOP_LAB012\\Parm.txt").ToList();
            List<string>[] list2 = new List<string>[] { list };
            try
            {
                object obj = Activator.CreateInstance(type);
                MethodInfo methodInfo = type.GetMethod(methode);
                Console.WriteLine(methodInfo.Invoke(obj,list2));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        public static void Create(string classname,string parm)
        {
            Type type = Type.GetType(classname);
            
            ConstructorInfo[] constructorInfo = type.GetConstructors();
            object obj = Activator.CreateInstance(type, args: parm);
            Console.WriteLine(obj.ToString());
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Reflector.GetName("OOP_LAB012.Program");
            Reflector.GetConstructors("OOP_LAB012.Program");
            Reflector.GetMethod("OOP_LAB012.Program");
            Reflector.GetField("OOP_LAB012.Program");
            Reflector.GetInterfece("OOP_LAB012.Program");
            Reflector.MethodForType("OOP_LAB012.Program", "Int32");
            Reflector.Voke("OOP_LAB012.pricol", "Toconsole");
            Reflector.Create("OOP_LAB012.pricol", "Vladik");

            Console.ReadKey();
        }
    }
}

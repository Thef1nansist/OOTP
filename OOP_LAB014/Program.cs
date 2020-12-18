using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Linq;

namespace OOP_LAB014
{
    class Phone
    {
        public string Name { get; set; }
        public string Price { get; set; }
    }

    class Program
    {
        Log Log = new Log();
        static void Main(string[] args)
        {
            #region main
            var myclass = new MyClass();
            var phone = new Phone();

            myclass.Name = "Vity";
            myclass.age = 12;


            var list = new List<MyClass>
            {
                new MyClass(),
                new MyClass(),
                new MyClass()
            };

            var binFormat = new BinaryFormatter();
            var sopaFormat = new SoapFormatter();
            var jsonFormat = new DataContractJsonSerializer(typeof(MyClass));
            var xmlFormat = new XmlSerializer(typeof(MyClass));
            #endregion

            #region serialization

            using (var asd = new FileStream("primer.dat", FileMode.OpenOrCreate))
            {
                binFormat.Serialize(asd, myclass);
                Log.WriteLog("log.txt","Объект сериализован в bin");
               
            }
            using (var asd = new FileStream("primer.xml", FileMode.OpenOrCreate))
            {
                xmlFormat.Serialize(asd, myclass);
                Log.WriteLog("log.txt", "Объект сериализован в xml");
            }
            using (var sad = new FileStream("primer.soap", FileMode.OpenOrCreate))
            {
                sopaFormat.Serialize(sad, myclass);
                Log.WriteLog("log.txt", "Объект сериализован в soap");
            }
            using(var sda = new FileStream("primer.json", FileMode.OpenOrCreate))
            {
                jsonFormat.WriteObject(sda, myclass);
                Log.WriteLog("log.txt", "Объект сериализован в json");
            }
            using (var sda = new FileStream("list.dat", FileMode.OpenOrCreate))
            {
                binFormat.Serialize(sda, list);
                Log.WriteLog("log.txt", "Объект list сериализован в json");
            }
            Console.ReadKey();
            #endregion
            #region deserialization
            using(var asd = new FileStream("primer.json", FileMode.OpenOrCreate))
            {
                var after = (MyClass)jsonFormat.ReadObject(asd);
                Console.WriteLine($"Name: {after.Name}\n");
                Log.WriteLog("log.txt", "Объект десериализован из json");
            }

            using(var asd = new FileStream("primer.dat", FileMode.OpenOrCreate))
            {
                var after = (MyClass)binFormat.Deserialize(asd);
                Console.WriteLine($"Name: {after.Name}\n");
                Log.WriteLog("log.txt", "Объект десериализован из bin");
            }

            using (var asd = new FileStream("primer.xml", FileMode.OpenOrCreate))
            {
                var after = (MyClass)xmlFormat.Deserialize(asd);
                Console.WriteLine($"Name: {after.Name}\n");
                Log.WriteLog("log.txt", "Объект десериализован из xml");
            }

            using (var asd = new FileStream("primer.soap", FileMode.OpenOrCreate))
            {
                var after = (MyClass)sopaFormat.Deserialize(asd);
                Console.WriteLine($"Name: {after.Name}\n");
                Log.WriteLog("log.txt", "Объект десериализован из soap");
            }
            using(var asd = new FileStream("list.dat", FileMode.OpenOrCreate))
            {
                var after = (List<MyClass>)binFormat.Deserialize(asd);
                Console.WriteLine($"Count of values in list = {after.Count} \n");
                Log.WriteLog("log.txt", "Объект(list) десериализован из .dat");
            }
            Console.ReadKey();

            #endregion

            #region xml request
            XmlDocument xml = new XmlDocument();
            xml.Load("D:\\UN\\OOP_LAB014\\bin\\Debug\\primer.xml");
            XmlElement xRoot = xml.DocumentElement;

            XmlNodeList xmlNodeList = xRoot.SelectNodes("*");
            XmlNodeList xmlName = xRoot.SelectNodes("Name");
            Console.WriteLine("\nПервый запрос");

            foreach (XmlNode n in xmlNodeList)
                Console.WriteLine(n.OuterXml);

            Console.WriteLine("\nВторой запрос");
            foreach (XmlNode n in xmlName)
                Console.WriteLine(n.OuterXml);
            Console.ReadLine();
            #endregion

            #region lasttask linq in xml
            XDocument xdoc = new XDocument(new XElement("phones",
            new XElement("phone",
                new XAttribute("name", "iPhone XR"),
                new XElement("company", "Apple"),
                new XElement("price", "2000")),
            new XElement("phone",
                new XAttribute("name", "Samsung Galaxy S8+"),
                new XElement("company", "Samsung"),
                new XElement("price", "1800"))));
            xdoc.Save("phones.xml");

            var items = from xe in xdoc.Element("phones").Elements("phone")
                        where xe.Element("company").Value == "Samsung"
                        select new Phone
                        {
                            Name = xe.Attribute("name").Value,
                            Price = xe.Element("price").Value
                        };

            foreach (var item in items)
                Console.WriteLine($"{item.Name} - {item.Price}");
            Console.ReadLine();
            #endregion

        }
    }
}

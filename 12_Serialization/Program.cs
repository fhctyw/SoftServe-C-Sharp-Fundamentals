using System.Drawing;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;
using static _04_Classes.Program;

namespace _12_Serialization
{
    internal static class Program
    {
        public readonly static string PathProject
            = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, "..", "..", "..")).FullName;

        public interface IFileObjectIO
        {
            bool Save<T>(string path, T obj);
            T? Read<T>(string path);
        }

        public class BinaryObjectIO : IFileObjectIO
        {
            protected IFormatter formatter;
            public BinaryObjectIO(IFormatter formatter)
            {
                this.formatter = formatter;
            }
            public BinaryObjectIO()
            {
                formatter = new BinaryFormatter();
            }
            public bool Save<T>(string path, T obj)
            {
                try
                {
                    using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write))
                    {
                        formatter.Serialize(stream, obj);
                    }
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }

            public T? Read<T>(string path)
            {
                T? obj = default(T);
                try
                {
                    using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        obj = (T)formatter.Deserialize(stream);
                    }
                }
                catch (Exception)
                {
                    return default(T);
                }
                return obj;
            }
        }

        public class XmlObjectIO : IFileObjectIO
        {
            protected XmlSerializer xmlser;

            public XmlObjectIO(XmlSerializer xmlser)
            {
                this.xmlser = xmlser;
            }
            public XmlObjectIO(Type type)
            {
                xmlser = new XmlSerializer(type);
            }

            public T? Read<T>(string path)
            {
                T? obj = default(T);
                try
                {
                    using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        obj = (T)xmlser.Deserialize(stream);
                    }
                }
                catch (Exception)
                {
                    return default(T);
                }
                return obj;
            }

            public bool Save<T>(string path, T obj)
            {
                try
                {
                    using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write))
                    {
                        xmlser.Serialize(stream, obj);
                    }
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }

        public class JsonObjectIO : IFileObjectIO
        {
            public T? Read<T>(string path)
            {
                T? obj = default(T);
                try
                {
                    obj = JsonSerializer.Deserialize<T>(File.ReadAllText(path));
                }
                catch (Exception)
                {
                    return default(T);
                }
                return obj;
            }

            public bool Save<T>(string path, T obj)
            {
                try
                {
                    File.WriteAllText(path, JsonSerializer.Serialize(obj));
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }

        static void Main()
        {
            Console.WriteLine("Car:");
            Car? car = new("Corolla", Color.Silver, 20000M);
            car.Print();
            Console.WriteLine();

            // Binary
            string filePath = Path.Combine(PathProject, "bird.bin");
            IFileObjectIO fileObject = new BinaryObjectIO();

            if (!fileObject.Save(filePath, car))
            {
                throw new Exception("Binary Error");
            }
            car = null;
            car = fileObject.Read<Car>(filePath);
            Console.WriteLine("Car after binary saving:");
            car.Print();
            Console.WriteLine();

            // Xml
            car = new("Corolla", Color.Silver, 20000M);
            filePath = Path.Combine(PathProject, "bird.xml");
            
            fileObject = new XmlObjectIO(typeof(Car));

            if (!fileObject.Save(filePath, car))
            {
                throw new Exception("Xml Error");
            }
            car = null;
            car = fileObject.Read<Car>(filePath);
            Console.WriteLine("Car after xml saving:");
            car.Print();
            Console.WriteLine();

            // Json
            car = new("Corolla", Color.Silver, 20000M);
            filePath = Path.Combine(PathProject, "bird.json");
            fileObject = new JsonObjectIO();

            if (!fileObject.Save(filePath, car))
            {
                throw new Exception("Json Error");
            }
            car = null;
            car = fileObject.Read<Car>(filePath);
            Console.WriteLine("Car after json saving:");
            car.Print();
            Console.WriteLine();
        }
    }
}
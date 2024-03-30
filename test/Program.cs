using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Xml;
using test.Entities;

namespace test
{
    internal class Program
    {
        public static Dictionary<string, Dictionary<PropertyInfo, string>> list = new Dictionary<string, Dictionary<PropertyInfo, string>>()
        {
            {"Book", new Dictionary<PropertyInfo, string>()
                {
                    { typeof(Book).GetProperty("Name"), "Название"},
                    { typeof(Book).GetProperty("Author"), "ФИО автора"},
                    { typeof(Book).GetProperty("Publisher"), "Издатель"},
                    { typeof(Book).GetProperty("YearOfPublication"), "Год издания"},
                    { typeof(Book).GetProperty("Genre.Name"), "Жанр"}
                }
            }
        };
        public static DBContext Context = new DBContext();
        static void Main()
        {
            Dictionary<string, Dictionary<PropertyInfo, string>> list = new Dictionary<string, Dictionary<PropertyInfo, string>>()
        {
            {"Book", new Dictionary<PropertyInfo, string>()
                {
                    { typeof(Book).GetProperty("Name"), "Название"},
                    { typeof(Book).GetProperty("Author"), "ФИО автора"},
                    { typeof(Book).GetProperty("Publisher"), "Издатель"},
                    { typeof(Book).GetProperty("YearOfPublication"), "Год издания"},
                    { typeof(Book).GetProperty("Genre"), "Жанр"}
                }
            }
        };
            var a = list.FirstOrDefault(x => x.Key == "Book").Value;
            var book = new DBContext().Books
                .Include(x => x.Author)
                .Include(x => x.Publisher)
                .Include(x => x.Genre)
                .FirstOrDefault();
            //var book = new Book();
            Type type = book.GetType();
            PropertyInfo[] property = type.GetProperties();
            //foreach (var item in a.Keys)
            //{
            //    if (item.GetMethod.IsVirtual)
            //    {
            //        Type type1 = item.PropertyType;
            //        Console.WriteLine("virtual: " + item.Name);
            //        if (item.Name != "Author")
            //        {
            //            property = type1.GetProperty($"Name");
            //            var add = property.ReflectedType.GetProperty($"Name");
            //            Console.WriteLine(add.GetValue(book));
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("Notvirtual: " + item.Name);
            //        property = type.GetProperty($"{item.Name}");
            //        Console.WriteLine(property.GetValue(book));
            //    }
            //    if (property != null)
            //    {
            //        //Console.WriteLine(new DBContext().Entry(book).Property(property.Name).CurrentValue);
            //    }

            //}

            foreach (var item in property)
            {
                if (item.GetMethod.IsVirtual)
                {
                    if (item.Name == "Publisher")
                    {
                        Type entityType = item.GetType();
                        PropertyInfo nameProperty = entityType.GetProperty("Name");
                        var entityChild = item.GetValue(book);
                        
                    }
                }
            }
            Console.Read();
            Main();
        }


    }
}

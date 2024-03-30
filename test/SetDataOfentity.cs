using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using test.Entities;

namespace test
{
    internal static class SetDataOfentity
    {
        // Список типов сущностей в БД
        private static  List<Type> EntityTypeList = new List<Type>
        {
          typeof(Author),
          typeof(Book),
          typeof(Gender),
          typeof(Genre),
          typeof(Post),
          typeof(PublishingHouse),
          typeof(Reader),
          typeof(Staff),
          typeof(TakenBook),
        };


        public static object SetData(object Entity, object Parametr, object Value)
        {
            Type type = GetTypeEntity(Entity);

            PropertyInfo propertyInfo = GetProperty(type, (string)Parametr);
            if (propertyInfo == null)
            {
                throw new Exception("Тип сущности не найден в EntityTypeList");
            }
            switch (type.Name)
            {
                case "Book":
                    Book book = (Book)Entity;
                    new DBContext().Entry(book).Property($"{propertyInfo.Name}").CurrentValue = Value;
                    return book;
            }
            return null;
        }
        private static void GetDataEntity(object entity)
        {
            //  ???
        }

        private static PropertyInfo GetProperty(Type type, string Name)
        {
            var property = type.GetProperty(Name);
            if (property == null)
            {
                throw new Exception($"Свойство: {property.Name} не существует в классе: {property.MemberType}");// ??
            }
            return property;
        }

        private static Type GetTypeEntity(object entity)
        {
            foreach (var itemType in EntityTypeList)
            {
                if (entity.GetType() == itemType)
                    return itemType;
            }
            throw new Exception("Тип сущности не найден в EntityTypeList");
        }

    }

}

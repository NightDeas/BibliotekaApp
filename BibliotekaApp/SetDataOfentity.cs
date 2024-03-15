using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using BibliotekaApp.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Windows.Themes;

namespace BibliotekaApp
{
    internal static class SetDataOfentity
    {
        static readonly List<Type> EntityTypeList = new List<Type>
        {
          
        };


        public static void SetData(object Entity, object Parametr, object Value)
        {
            var sdfdsf = new Entites.Book();
            var a = new Book().GetType();
            var b= a.GetProperties();
            Entites.Book book = new();
        }

        private static void GetDataEntity(object entity)
        {
        }

    }
}

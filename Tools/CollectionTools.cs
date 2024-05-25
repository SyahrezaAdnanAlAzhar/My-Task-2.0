using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class CollectionTools
    {

        public static void Sorting<T>(IEnumerable<T> collection, bool ascending = true) where T : IComparable<T>
        {

        }

        // menambahkan item pada index ter belakang
        public static void Append<T>(IEnumerable<T> collection, T item) where T : IComparable<T>
        {

        }

        // menambahkan item pada index tertentu
        public static void Insert<T>(IEnumerable<T> collection, T item, int index = 0) where T : IComparable<T>
        {

        }

        // menghapus element terakhir
        public static void Pop<T>(IEnumerable<T> collection) where T : IComparable<T>
        {

        }

        // menghapus suatu element
        public static void Remove<T>(IEnumerable<T> collection, T item) where T : IComparable<T>
        {

        }

        // mencari suatu element berdasarkan suatu attribute nya
        public static IEnumerable<T> Search<T>(IEnumerable<T> collection, string desc, Func<T, string> propertySelector) where T : IComparable<T>
        {
            //return collection.Where(e => propertySelector(e).Equals(desc, StringComparison.OrdinalIgnoreCase));
            return null;
        }

        // mencari suatu element
        public static IEnumerable<T> Search<T>(IEnumerable<T> collection, T item) where T : IComparable<T>
        {
            return null;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class CollectionTools
    {
        // melakukan sorting dari suatu collection yang hanya menyimpan satu data tiap elementnya
        public static void Sorting<T>(IEnumerable<T> collection, bool ascending = true) 
        {

        }

        // melakukan sorting dari suatu collection berdasarkan nilai attribute dari suatu object yang tersimpan di setiap elementnya
        public static void Sorting<T, TKey>(IEnumerable<T> collection, Func<T, TKey> keySelector, bool ascending = true)
        {
            var list = collection.ToList();
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list.Count - 1 - i; j++)
                {
                    bool condition;
                    if (ascending)
                    {
                        condition = Comparer<TKey>.Default.Compare(keySelector(list[j]), keySelector(list[j + 1])) > 0;
                    }
                    else
                    {
                        condition = Comparer<TKey>.Default.Compare(keySelector(list[j]), keySelector(list[j + 1])) < 0;
                    }
                    if (condition)
                    {
                        var temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
        }

        // menambahkan item pada index ter belakang
        public static void Append<T>(IEnumerable<T> collection, T item)
        {

        }

        // menambahkan item pada index tertentu
        public static void Insert<T>(IEnumerable<T> collection, T item, int index = 0)
        {

        }

        // menghapus element terakhir
        public static void Pop<T>(IEnumerable<T> collection)
        {

        }

        // menghapus suatu element
        public static void Remove<T>(IEnumerable<T> collection, T item)
        {

        }

        // mencari suatu element berdasarkan suatu attribute nya
        public static T Search<T>(IEnumerable<T> collection, string desc, Func<T, string> propertySelector)
        {
            foreach (var element in collection)
            {
                var propertyValue = propertySelector(element);

                if (string.Equals(propertyValue, desc))
                {
                    return element;
                }
            }
            return default(T);
        }

        // mencari suatu element
        public static T Search<T>(IEnumerable<T> collection, T item)
        {
            return default(T);
        }


    }
}

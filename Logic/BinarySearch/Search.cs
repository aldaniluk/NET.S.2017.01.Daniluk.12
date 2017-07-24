using System;
using System.Collections.Generic;

namespace Logic
{
    public static class Search
    {
        /// <summary>
        /// Searches an element in the array using binary search method.
        /// </summary>
        /// <typeparam name="T">Any type for search.</typeparam>
        /// <param name="array">Array of elements.</param>
        /// <param name="element">Element for search.</param>
        /// <param name="comparer">Type for comparison elements.</param>
        /// <returns>Index of element in the array and -1, if element was not found.</returns>
        public static int BinarySearch<T>(this T[] array, T element, IComparer<T> comparer) 
        {
            CheckArray(array);
            if (comparer.Compare(element, array[0]) < 0 || comparer.Compare(element, array[array.Length - 1]) > 0) return -1;
            
            int start = 0;
            int finish = array.Length - 1;
            int middle;

            while (start < finish)
            {
                middle = (start + finish) / 2;

                if (comparer.Compare(element, array[middle]) == 0)
                {
                    return middle;
                }
                else if (comparer.Compare(element, array[middle]) < 0)
                {
                    finish = middle;
                }
                else
                {
                    start = middle + 1;
                }
            }
            return (comparer.Compare(array[finish], element) == 0) ? finish : -1;
        }

        private static void CheckArray<T>(T[] array)
        {
            if (ReferenceEquals(array, null)) throw new ArgumentNullException($"{nameof(array)} is null.");
            if (array.Length == 0) throw new ArgumentException($"{nameof(array)} is empty.");
        }
    }
}

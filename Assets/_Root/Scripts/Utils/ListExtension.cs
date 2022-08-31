using System.Collections.Generic;
using UnityEngine;

namespace Extension
{
    public static class ListExtension
    {
        public static T GetRandom<T>(this List<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }

        public static T GetRandomAndRemove<T>(this List<T> list)
        {
            int index = Random.Range(0, list.Count);
            T returnValue = list[index];
            list.RemoveAt(index);
            return returnValue;
        }
    }
}

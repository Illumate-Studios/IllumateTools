using UnityEngine;
using System.Diagnostics;
using System.Collections.Generic;

public static class DebugExtensions
{
    /// <summary>
    /// Draw gizmos' for vector3 positions
    /// </summary>
    /// <param name="pointList"></param>
    //public static void Display(this Vector3[] pointList)
    //{
    //    foreach (var point in pointList)
    //    {
    //        Dbg.Point(point);
    //    }
    //}

    [DebuggerHidden]
    public static void Print<T>(this List<T> list)
    {
        if (list == null)
        {
            UnityEngine.Debug.Log("Null list: " + list);
            return;
        }
        list.ToArray().Print();
    }



    [DebuggerHidden]
    public static void Print<T>(this T[] array)
    {
        if (array == null)
        {
            UnityEngine.Debug.Log("Null array: " + array);
            return;
        }

        string ret = "Array with length: " + array.Length + "\n";
        for (int i = 0; i < array.Length; i++)
        {
            ret += array[i] == null ? "null" : array[i].ToString();
            if (i != array.Length - 1)
                ret += "\n";
        }
        UnityEngine.Debug.Log(ret);
        // PERFORMANCE
    }

    [DebuggerHidden]
    public static void Print<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
    {
        if (dictionary == null)
        {
            UnityEngine.Debug.Log("Null dictionary: " + dictionary);
            return;
        }

        string ret = "Array with length: " + dictionary.Count + "\n";
        foreach (var kv in dictionary)
        {
            ret += kv.Key + ": " + kv.Value + "\n";
        }
        UnityEngine.Debug.Log(ret);
    }
}


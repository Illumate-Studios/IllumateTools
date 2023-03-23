using System;
using System.Collections.Generic;

public static class MyExtensions
{
    /// <summary>
    /// Remap number from range to a range
    /// </summary>
    /// <param name="value"></param>
    /// <param name="from1"></param>
    /// <param name="to1"></param>
    /// <param name="from2"></param>
    /// <param name="to2"></param>
    /// <returns></returns>
    public static float Remap(this float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <param name="length"></param>
    /// <param name="paddingChar"></param>
    /// <returns></returns>
    public static string PadBoth(this string str, int length, char paddingChar = ' ')
    {
        int spaces = length - str.Length;
        int padLeft = spaces / 2 + str.Length;
        return str.PadLeft(padLeft, paddingChar).PadRight(length, paddingChar);
    }

    /// <summary>
    /// Get string until a specific character
    /// </summary>
    /// <param name="text"></param>
    /// <param name="stopAt"></param>
    /// <returns></returns>
    public static string GetUntilOrEmpty(this string text, string stopAt)
    {
        if (!string.IsNullOrWhiteSpace(text))
        {
            int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

            if (charLocation > 0)
            {
                return text.Substring(0, charLocation);
            }
        }

        return string.Empty;
    }


    // TODO: make enumerable

    /// <summary>
    /// Get nearest to position
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="list"></param>
    /// <param name="position"></param>
    /// <param name="selector"></param>
    /// <returns></returns>
    public static TResult GetNearest<TResult>(this TResult[] list, UnityEngine.Vector3 position, Func<TResult, UnityEngine.Vector3> selector) where TResult : class
    {
        TResult nearest = null;
        float nearestDistSqr = float.MaxValue;
        for (int i = 0; i < list.Length; i++)
        {
            float distSqr = UnityEngine.Vector3.SqrMagnitude(selector.Invoke(list[i]) - position);
            if (distSqr < nearestDistSqr)
            {
                nearest = list[i];
                nearestDistSqr = distSqr;
            }
        }
        return nearest;
    }

    /// <summary>
    /// Get nearest one to a point.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="list"></param>
    /// <param name="position">Position of point Ex. GetPos()</param>
    /// <param name="selector">Selector function of other elements Ex. (agent) => agent.GetPos()</param>
    /// <param name="condition">Include only if condition is true Ex. (agent) => agent.isHostile()</param>
    /// <returns></returns>
    public static TResult GetNearest<TResult>(this List<TResult> list, UnityEngine.Vector3 position, Func<TResult, UnityEngine.Vector3> selector, Func<TResult, bool> condition = null) where TResult : class
    {
        TResult nearest = null;
        float nearestDistSqr = float.MaxValue;
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] == null || list[i].Equals(null))
                continue;

            if (condition != null && !condition.Invoke(list[i]))
                continue;

            float distSqr = UnityEngine.Vector3.SqrMagnitude(selector.Invoke(list[i]) - position);
            if (distSqr < nearestDistSqr)
            {
                nearest = list[i];
                nearestDistSqr = distSqr;
            }
        }
        return nearest;
    }


    /// <summary>
    /// Resize and add element to end of the array
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    //public static T[] Add<T>(this T[] array, T value)
    //{
    //    Array.Resize(ref array, array.Length + 1);
    //    array[array.Length - 1] = value;
    //    return array;
    //}
}
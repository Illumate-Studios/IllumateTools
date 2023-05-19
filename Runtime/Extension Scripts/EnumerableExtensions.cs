public static class EnumerableExtensions
{
    /// <summary>
    /// Return values shuffled
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array"></param>
    public static T[] Shuffle<T>(this T[] array)
    {
        T temp;
        for (int i = 0; i < array.Length; i++)
        {
            int rnd = UnityEngine.Random.Range(0, array.Length);
            temp = array[rnd];
            array[rnd] = array[i];
            array[i] = temp;
        }
        return array;
    }

    public static T[] SelectSample<T>(this T[] array, int count)
    {
        // TODO: performance
        var a = array.Shuffle();
        var ret = new T[count];
        for (int i = 0; i < count; i++)
            ret[i] = a[i];
        return ret;
    }
}

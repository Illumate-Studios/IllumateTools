using System.Diagnostics;

namespace UnityEngine
{
    /// <summary>
    /// Custom debug class
    /// </summary>
    public static class Dbg
    {
        /// <summary>
        /// Mark point
        /// </summary>
        /// <param name="point"></param>
        public static void Point(Vector3 point)
        {
            const float size = 0.3f;
            UnityEngine.Debug.DrawLine(point + Vector3.up * size, point + Vector3.down * size, Color.red);
            UnityEngine.Debug.DrawLine(point + Vector3.right * size, point + Vector3.left * size, Color.red);
            UnityEngine.Debug.DrawLine(point + Vector3.forward * size, point + Vector3.back * size, Color.red);
        }


        /// <summary>
        /// Shortcut for Debug.Log
        /// </summary>
        /// <param name="object"></param>
        [DebuggerHidden]
        public static void W(object @object)
        {
            Debug.Log(@object);
        }
    }
}



using System.Diagnostics;

namespace UnityEngine
{
    /// <summary>
    /// Custom debug class
    /// </summary>
    public static class Dbg
    {
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



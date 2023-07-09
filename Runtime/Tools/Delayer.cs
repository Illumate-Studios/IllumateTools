using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Illumate.Tools
{
    public static class Delayer
    {
        /// <summary>
        /// Run action after WaitForEndOfFrame
        /// </summary>
        /// <param name="action"></param>
        public static void EndOfFrame(Action action)
        {
            ExistingObject.RunEnumerator(EndOfFrameCR(action));
        }

        /// <summary>
        /// Run action after a time
        /// </summary>
        /// <param name="time"></param>
        /// <param name="action"></param>
        public static void DelayTime(float time, Action action)
        {
            ExistingObject.RunEnumerator(DelayCR(time, action));
        }

        /// <summary>
        /// Run action after {count} frame
        /// </summary>
        /// <param name="action"></param>
        /// <param name="count"></param>
        public static void DelayFrame(Action action, int count = 1)
        {
            ExistingObject.RunEnumerator(DoAfterFrameCR(action, count));
        }        

        // ---------------------- Coroutines ----------------------

        private static IEnumerator DelayCR(float time, Action action)
        {
            yield return new WaitForSeconds(time);

            action?.Invoke();
        }

        private static IEnumerator DoAfterFrameCR(Action action, int count)
        {
            for (int i = 0; i < count; i++)
                yield return null;

            action.Invoke();
        }

        private static IEnumerator EndOfFrameCR(Action action)
        {
            yield return new WaitForEndOfFrame();
            action.Invoke();
        }
    }
}
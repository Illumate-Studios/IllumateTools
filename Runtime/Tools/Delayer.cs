using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace IllumateStudios.Tools
{
    public static class Delayer
    {
        /// <summary>
        /// Run action after a time
        /// </summary>
        /// <param name="time"></param>
        /// <param name="action"></param>
        public static void Delay(float time, Action action)
        {
            BehaviourWorker.RunEnumerator(DelayCR(time, action));
        }

        /// <summary>
        /// Run action after {count} frame
        /// </summary>
        /// <param name="action"></param>
        /// <param name="count"></param>
        public static void DoAfterFrame(Action action, int count = 1)
        {
            BehaviourWorker.RunEnumerator(DoAfterFrameCR(action, count));
        }

        /// <summary>
        /// Run function once every {frameGap} frame
        /// </summary>
        /// <param name="function"></param>
        /// <param name="monoBehaviour"></param>
        /// <param name="frameGap"></param>
        public static void SetLazyUpdate(Action function, MonoBehaviour monoBehaviour, int frameGap = 10)
        {
            monoBehaviour.StartCoroutine(LazyUpdaterCR(function, frameGap));
        }

        /// <summary>
        /// Run function once every {seconds} second
        /// </summary>
        /// <param name="function"></param>
        /// <param name="monoBehaviour"></param>
        /// <param name="seconds"></param>
        public static void SetLazyUpdate(Action function, MonoBehaviour monoBehaviour, float seconds = 1)
        {
            monoBehaviour.StartCoroutine(LazyTimeUpdaterCR(function, seconds));
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

        private static IEnumerator LazyUpdaterCR(Action updateFunction, int frameGap)
        {
            while (true)
            {
                updateFunction.Invoke();
                for (int i = 0; i < frameGap; i++)
                {
                    yield return null;
                }
            }
        }

        private static IEnumerator LazyTimeUpdaterCR(Action updateFunction, float seconds)
        {
            while (true)
            {
                updateFunction.Invoke();
                yield return new WaitForSeconds(seconds);
            }
        }
    }


}
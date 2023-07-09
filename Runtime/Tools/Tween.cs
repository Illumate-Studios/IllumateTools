using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Illumate.Tools
{

    //public class IlluTween : MonoBehaviour
    //{
    //    private List<Interval> intervals = new List<Interval>();
    //    private static IlluTween _instance;
    //    private static IlluTween instance
    //    {
    //        get
    //        {
    //            if (_instance == null)
    //            {
    //                _instance = new GameObject("Tween").AddComponent<IlluTween>();
    //            }
    //            return _instance;
    //        }
    //    }


    //    public static Interval To(float duration, Action<float> onUpdate, Action onComplete)
    //    {
    //        Interval ret = new Interval(duration, onUpdate, onComplete);
    //        instance.intervals.Add(ret);
    //        return ret;
    //    }


    //    private void Update()
    //    {
    //        foreach (Interval interval in intervals)
    //        {
    //            if (!interval.Tick())
    //            {
    //                intervals.Remove(interval);
    //            }
    //        }
    //    }


    //    public class Interval
    //    {
    //        public bool isRunning { get; private set; } = true;

    //        private readonly float duration;
    //        private readonly Action<float> onUpdate;
    //        private readonly Action onComplete;

    //        private float l = 0;

    //        public Interval(float duration, Action<float> onUpdate, Action onComplete)
    //        {
    //            this.duration = duration;
    //            this.onUpdate = onUpdate;
    //            this.onComplete = onComplete;
    //        }

    //        /// <summary>
    //        /// Tick the tween and return false if ended
    //        /// </summary>
    //        /// <returns></returns>
    //        internal bool Tick()
    //        {
    //            if (!isRunning)
    //            {
    //                return false;
    //            }

    //            l += Time.deltaTime / duration;
    //            if (1 <= l)
    //                l = 1;

    //            onUpdate.Invoke(l);

    //            if (l == 1)
    //            {
    //                onComplete.Invoke();
    //                return false;
    //            }
    //            return true;
    //        }

    //        public void Stop(bool complete = true)
    //        {
    //            isRunning = true;
    //            if (complete)
    //                onComplete(); // IDEA: running complete on update better?
    //        }
    //    }
    //}

}
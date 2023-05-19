using System;
using System.Collections;
using UnityEngine;

namespace IllumateStudios.Tools
{
    public class TimedAction
    {
        private Action onStart, onUpdate, onEnd;
        private float duration;
        private float updateInterval;

        public TimedAction(float duration, float updateInterval = 0)
        {
            this.duration = duration;
            this.updateInterval = updateInterval;
        }

        public TimedAction OnStart(Action onStart)
        {
            this.onStart = onStart;
            return this;
        }
        public TimedAction OnUpdate(Action onUpdate)
        {
            this.onUpdate = onUpdate;
            return this;
        }
        public TimedAction OnEnd(Action onEnd)
        {
            this.onEnd = onEnd;
            return this;
        }

        /// <summary>
        /// Start this timed action
        /// </summary>
        public void Invoke()
        {
            if (updateInterval != 0)
                ExistingObject.RunEnumerator(TimedActionIntervalCR());
            else if (onUpdate == null)
                ExistingObject.RunEnumerator(TimedActionNoUpdateCR());
            else
                ExistingObject.RunEnumerator(TimedActionCR());
        }

        private IEnumerator TimedActionCR()
        {
            onStart?.Invoke();
            float bTime = Time.time;
            while (Time.time - bTime < duration)
            {
                onUpdate?.Invoke();
                yield return null;
            }
            onEnd?.Invoke();
        }

        private IEnumerator TimedActionIntervalCR()
        {
            onStart?.Invoke();
            float bTime = Time.time;
            while (Time.time - bTime < duration)
            {
                onUpdate?.Invoke();
                yield return new WaitForSeconds(updateInterval);
            }
            onEnd?.Invoke();
        }

        private IEnumerator TimedActionNoUpdateCR()
        {
            onStart?.Invoke();
            yield return new WaitForSeconds(duration);
            onEnd?.Invoke();
        }

    }

}
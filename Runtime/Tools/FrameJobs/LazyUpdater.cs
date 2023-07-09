using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Illumate.Tools
{
    public class LazyUpdater : FrameJobComponent<LazyUpdater>
    {
        private Dictionary<MonoBehaviour, int> lazyUpdates = new Dictionary<MonoBehaviour, int>();
        private List<MonoBehaviour> keysToRemove = new List<MonoBehaviour>();

        private void Update()
        {
            foreach (var m in lazyUpdates)
            {
                if (framePassed % m.Value != 0 || !m.Key.isActiveAndEnabled)
                    continue;

                // Check if null or destroyed
                if (m.Key == null || m.Key.Equals(null))
                {
                    keysToRemove.Add(m.Key);
                    continue;
                }

                (m.Key as ILazyUpdate).LazyUpdate();
            }

            foreach (var key in keysToRemove)
            {
                lazyUpdates.Remove(key);
            }
            keysToRemove.Clear();
        }

        /// <summary>
        /// Run LazyUpdate() every frameInterval frames.
        /// </summary>
        /// <param name="monoBehaviour">this (has to be ILazyUpdate)</param>
        /// <param name="frameInterval"></param>
        public static void Init(MonoBehaviour monoBehaviour, int frameInterval = 30)
        {
            if (monoBehaviour is ILazyUpdate)
            {
                if (!Instance.lazyUpdates.ContainsKey(monoBehaviour))
                {
                    Instance.lazyUpdates.Add(monoBehaviour, frameInterval);
                }
                else
                {
                    Debug.LogWarning($"{monoBehaviour} is already registered for lazy update.");
                }
            }
            else
            {
                Debug.LogError(monoBehaviour + " is not " + typeof(ILazyUpdate));
            }
        }
    }

    public interface ILazyUpdate
    {
        public void LazyUpdate();
    }
}

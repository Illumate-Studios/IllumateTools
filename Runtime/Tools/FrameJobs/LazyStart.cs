using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IllumateStudios.Tools
{
    public class LazyStart : FrameJobComponent<LazyStart>
    {
        private Queue<MonoBehaviour> lazyStarts = new Queue<MonoBehaviour>();

        private const int LAZYSTART_BEGIN_FRAME = 8;
        private const int LAZYSTART_SPREAD_FRAME = 256;

        private void Start()
        {
            StartCoroutine(LazyStartsCR());
        }


        private IEnumerator LazyStartsCR()
        {
            yield return new WaitForFrames(LAZYSTART_BEGIN_FRAME);

            int frameInterval = LAZYSTART_SPREAD_FRAME / lazyStarts.Count;
            while (lazyStarts.Count > 0)
            {
                (lazyStarts.Dequeue() as ILazyStart).LazyStart();
                yield return new WaitForFrames(frameInterval);
            }
        }


        /// <summary>
        /// Queues the LazyStart's and spreads them into first 256 frame
        /// </summary>
        /// <param name="monoBehaviour"></param>
        public static void Init(MonoBehaviour monoBehaviour)
        {
            if (monoBehaviour is ILazyStart)
            {
                if (LAZYSTART_BEGIN_FRAME < Instance.framePassed)
                    Instance.lazyStarts.Enqueue(monoBehaviour);
                else
                    (monoBehaviour as ILazyStart).LazyStart();
            }
            else
            {
                Debug.LogError(monoBehaviour + " is not " + typeof(ILazyStart));
            }
        }


    }

    public interface ILazyStart
    {
        public void LazyStart();
    }
}

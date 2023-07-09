using UnityEngine;

namespace Illumate.Tools
{
    public abstract class FrameJobComponent<T> : MonoBehaviour where T : FrameJobComponent<T>
    {
        private static T _instance;
        protected static T Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FrameJobs.Instance.gameObject.AddComponent<T>();
                return _instance;
            }
        }
        protected int framePassed => FrameJobs.Instance.framePassed;
        internal FrameJobs frameJobs => FrameJobs.Instance;
    }
}

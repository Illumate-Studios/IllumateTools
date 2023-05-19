using UnityEngine;

namespace IllumateStudios.Tools
{
    public class BeforeRender : FrameJobComponent<BeforeRender>
    {
        public static void Init(MonoBehaviour monoBehaviour)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IBeforeRender
    {
        public void BeforeRender();
    }
}

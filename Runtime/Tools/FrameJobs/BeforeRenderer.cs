using UnityEngine;

namespace Illumate.Tools
{
    public class BeforeRenderer : FrameJobComponent<BeforeRenderer>
    {
        public static void Init(MonoBehaviour monoBehaviour)
        {
            if (monoBehaviour is IBeforeRender)
            {
                throw new System.NotImplementedException();
            }
            else
            {
                Debug.LogError(monoBehaviour + " is not " + typeof(IBeforeRender));
            }
        }
    }

    public interface IBeforeRender
    {
        public void BeforeRender();
    }
}

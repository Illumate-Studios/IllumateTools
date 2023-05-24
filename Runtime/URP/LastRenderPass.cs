using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace IllumateStudios.URP
{
    internal class LastRenderPass : ScriptableRenderPass
    {
        public static LastRenderPass Instance => new();

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
                return;
#endif
            PostPreRenderer.PPRenderables.RemoveNulls();

            PostPreRenderer.PPRenderables.ExecutePreRenders();
        }
    }

}


using UnityEngine.Rendering.Universal;

namespace IllumateStudios.URP
{
    [System.Serializable]
    internal class IllumatePostProcessRendererFeature : ScriptableRendererFeature
    {
        private LastRenderPass lastRenderPass;

        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            renderer.EnqueuePass(lastRenderPass);
        }

        public override void Create()
        {
            lastRenderPass = LastRenderPass.Instance;
        }
    }
}

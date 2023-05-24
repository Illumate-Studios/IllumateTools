using System;
using UnityEngine.Rendering;
using System.Collections.Generic;
using UnityEngine;


namespace IllumateStudios.URP
{
    /// <summary>
    /// Class that holds and make processes over IPostPreRendered objects
    /// </summary>
    internal class PostPreRenderables
    {
        private List<PostPreRenderablesData> items = new();
        private List<PostPreRenderablesData> itemsToRemove = new();


        public void Add(IPostPreRendered postPreRendered)
        {
            PostPreRenderablesData data = new PostPreRenderablesData(postPreRendered);
            items.Add(data);
            RenderPipelineManager.endCameraRendering += data.postRenderAction;
        }
        public void Remove(IPostPreRendered postPreRendered)
        {
            foreach (var ppr in items)
            {
                if (ppr.postPreRendered == postPreRendered)
                {
                    Remove(ppr);
                    return;
                }
            }
        }
        public void RemoveNulls()
        {
            foreach (var item in items)
            {
                if (item.IsNull)
                    itemsToRemove.Add(item);
            }

            foreach (var item in itemsToRemove)
            {
                Remove(item);
            }
            itemsToRemove.Clear();
        }
        private void Remove(PostPreRenderablesData data)
        {
            RenderPipelineManager.endCameraRendering -= data.postRenderAction;
            items.Remove(data);
        }

        public void ExecutePreRenders()
        {
            foreach (var ppr in items)
                ppr.postPreRendered.PreRenderAction();
        }

        private class PostPreRenderablesData
        {
            public delegate void RenderPipelineDelegate(ScriptableRenderContext src, Camera cam);

            public IPostPreRendered postPreRendered;
            public Action<ScriptableRenderContext, Camera> postRenderAction; //PERFORMANCE: Using action at every frame is not good for performance

            public PostPreRenderablesData(IPostPreRendered postPreRendered)
            {
                this.postPreRendered = postPreRendered;
                postRenderAction = (_, _) => postPreRendered.PostRenderAction();
            }

            public bool IsNull => postPreRendered == null || postPreRendered.Equals(null);
        }
    }

    /// <summary>
    /// Interface that allows to execute code before and after the camera renders
    /// Initialize with PostPreRenderer.Add(this);
    /// </summary>
    public interface IPostPreRendered
    {
        void PreRenderAction();
        void PostRenderAction();
    }
}
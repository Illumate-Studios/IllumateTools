using UnityEngine;

namespace Illumate.Tools
{
    /// <summary>
    /// Advanced life cycle functions for MonoBehaviour.
    /// </summary>
    internal class FrameJobs : MonoExistSignleton<FrameJobs>
    {
        internal int framePassed { get; private set; } = 0;

        private void Update()
        {
            framePassed++;
        }
    }
}
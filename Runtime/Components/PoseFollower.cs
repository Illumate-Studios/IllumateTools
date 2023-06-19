using UnityEngine;

public class PoseFollower : MonoBehaviour
{
    [SerializeField] public PoseProvider poseProvider;

    private void Update()
    {
        if (poseProvider == null)
            return;

        transform.SetPositionAndRotation(
            poseProvider.GetPose().position,
            poseProvider.GetPose().rotation
        );
    }
}

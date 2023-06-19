using UnityEngine;

public class PoseProvider : MonoBehaviour
{
    [SerializeField] protected Vector3 positionOffset;
    [SerializeField] protected Vector3 rotationOffset;

    public virtual Pose GetPose() => new Pose(
        transform.position + positionOffset,
        transform.rotation * Quaternion.Euler(rotationOffset)
        );
}

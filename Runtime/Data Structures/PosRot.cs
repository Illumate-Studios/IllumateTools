// TODO: performance

namespace UnityEngine
{
    [System.Serializable]
    public struct PosRot
    {
        public Vector3 position;

        public Vector3 eulerAngles;

        public Quaternion rotation
        {
            get { return Quaternion.Euler(eulerAngles); }
            set { eulerAngles = value.eulerAngles; }
        }


        public PosRot(Vector3 position, Quaternion rotation)
        {
            this.position = position;
            this.eulerAngles = rotation.eulerAngles;
        }
        public PosRot(Vector3 position, Vector3 eulerAngles)
        {
            this.position = position;
            this.eulerAngles = eulerAngles;
        }
        public PosRot(Transform transform)
        {
            position = transform.position;
            eulerAngles = transform.eulerAngles;
        }

        public static PosRot Lerp(PosRot a, PosRot b, float t)
        {
            return new PosRot(
                Vector3.Lerp(a.position, b.position, t),
                Quaternion.Lerp(a.rotation, b.rotation, t)
                );
        }

    }

    public static class PosRotExtensions
    {
        /// <summary>
        /// Set transform position and rotation
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="posrot"></param>
        public static void SetPosRot(this Transform transform, PosRot posrot)
        {
            transform.position = posrot.position;
            transform.rotation = posrot.rotation;
        }

        public static PosRot GetPosRot(this Transform transform)
        {
            return new PosRot(transform);
        }

    }
}

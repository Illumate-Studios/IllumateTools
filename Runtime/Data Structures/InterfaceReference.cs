namespace UnityEngine
{
    /// <summary>
    /// Interfaces are not serializable, so this is a workaround to allow them to be serialized.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [System.Serializable]
    public class IRef<T> : ISerializationCallbackReceiver where T : class
    {
        public T I { get => Reference as T; }

        [SerializeField] private Object Reference;


        public static implicit operator bool(IRef<T> ir) => ir.Reference != null;
        void OnValidate()
        {
            if (Reference is not T)
            {
                if (Reference is GameObject go)
                {
                    foreach (Component c in go.GetComponents<Component>())
                    {
                        if (c is T)
                        {
                            Reference = c;
                            break;
                        }
                    }
                }
            }
            if (I == null) Reference = null;
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize() => this.OnValidate();
        void ISerializationCallbackReceiver.OnAfterDeserialize() { }
    }
}
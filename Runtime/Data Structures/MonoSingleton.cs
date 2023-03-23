using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T: MonoSingleton<T>
{
    private static volatile T _instance = null;

    public static T Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<T>();
            
            return _instance;
        }
    }

    private void OnDestroy()
    {
        if (_instance == this)
            _instance = null;
    }
}

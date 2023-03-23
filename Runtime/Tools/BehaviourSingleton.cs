using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourWorker : MonoBehaviour
{
    private static GameObject _monoObject;
    public static GameObject monoObject
    {
        get
        {
            if (_monoObject == null)
                _monoObject = new GameObject("MonoObject");
            return _monoObject;
        }
    }

    private static MonoBehaviour _monoBehaviour;
    public static MonoBehaviour monoBehaviour
    {
        get
        {
            if(_monoBehaviour == null)
                _monoBehaviour = monoObject.AddComponent<BehaviourWorker>();
            return _monoBehaviour;
        }
    }

    public static Coroutine RunEnumerator(IEnumerator enumerator)
    {
        return monoBehaviour.StartCoroutine(enumerator);
    }
}

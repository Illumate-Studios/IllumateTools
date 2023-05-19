using System.Collections;
using UnityEngine;

namespace IllumateStudios.Tools
{
    /// <summary>
    /// Just exists in the scene. Base for some static classes, enumerators etc.
    /// Don't use much.
    /// </summary>
    internal class ExistingObject : MonoExistSignleton<ExistingObject>
    {
        public static GameObject monoObject => Instance.gameObject;
        public static MonoBehaviour monoBehaviour => Instance;



        public static Coroutine RunEnumerator(IEnumerator enumerator)
        {
            return monoBehaviour.StartCoroutine(enumerator);
        }
    }
}

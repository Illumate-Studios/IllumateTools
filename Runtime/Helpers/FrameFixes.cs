using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace IllumateStudios.Helper
{
    /// <summary>
    /// Testing purposes only
    /// </summary>
    public class FrameFixes : MonoBehaviour
    {
        [SerializeField] private UnityEvent onEndOfFrame;
        [SerializeField] private UnityEvent onAfterFrame;
        [SerializeField] private UnityEvent onSecondEndOfFrame;
        [SerializeField] private UnityEvent on1SecondAfter;

        private void Start()
        {
            StartCoroutine(frameEnumerator());
        }

        private IEnumerator frameEnumerator()
        {
            yield return new WaitForEndOfFrame();
            onEndOfFrame.Invoke();

            yield return null;
            onAfterFrame.Invoke();

            yield return new WaitForEndOfFrame();
            onSecondEndOfFrame.Invoke();

            yield return new WaitForSeconds(1);
            on1SecondAfter.Invoke();
        }
    }
}

using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace Illumate.Helper
{
    /// <summary>
    /// For checking is problems could be solved by executing different moments of frame
    /// </summary>
    [AddComponentMenu("Illumate Helpers/Frame Testing")]
    public class FrameTesting : MonoBehaviour
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

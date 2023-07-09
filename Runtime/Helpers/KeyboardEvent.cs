using UnityEngine;
using UnityEngine.Events;

namespace Illumate.Helper
{
    public class KeyboardEvent : MonoBehaviour
    {
        [SerializeField] private KeyCode KeyboardButton = KeyCode.S;
        [SerializeField] private UnityEvent unityEvent;
        

        private void Update()
        {
            if (Input.GetKeyDown(KeyboardButton))
            {
                unityEvent?.Invoke();
            }
        }
    }
}
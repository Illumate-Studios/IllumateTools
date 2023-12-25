using UnityEngine;
using UnityEngine.InputSystem;

namespace Illumate.RuntimeDebugPanel
{
    public class RDPCanvas : MonoBehaviour
    {
        [SerializeField] private InputAction toggleInput;
        [SerializeField] private RDPPanelsSC panelsList;
        [Space]
        [SerializeField] private GameObject mainPanel;
        [SerializeField] private Transform listTransform;


        private void Start()
        {
            foreach (var panel in panelsList.panels)
            {
                Instantiate(panel, listTransform);
            }
        }


        private void OnEnable()
        {
            toggleInput.Enable();
            toggleInput.performed += TogglePerformed;
        }
        private void OnDisable()
        {
            toggleInput.Disable();
            toggleInput.performed -= TogglePerformed;
        }

        private void TogglePerformed(InputAction.CallbackContext obj)
        {
            mainPanel.SetActive(mainPanel.activeSelf);
        }
    }
}

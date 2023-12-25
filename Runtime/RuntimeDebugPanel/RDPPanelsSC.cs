using UnityEngine;

namespace Illumate.RuntimeDebugPanel
{
    [CreateAssetMenu(fileName = "RuntimeDebugPanels", menuName = "Illumate/Runtime Debug Panels DB")]
    public class RDPPanelsSC : ScriptableObject
    {
        public RDPPanel[] panels;
    }
}

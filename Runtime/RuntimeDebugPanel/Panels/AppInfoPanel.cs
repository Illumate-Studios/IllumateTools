using UnityEngine;
using UnityEngine.SceneManagement;

namespace Illumate.RuntimeDebugPanel
{
    public class AppInfoPanel : RDPPanel
    {
        [SerializeField] private TMPro.TMP_Text infoText;

        private void Awake()
        {
            infoText.text =
                $"Version: {Application.version}\n" +
                $"Scene: {SceneManager.GetActiveScene().name}";
        }
    }
}
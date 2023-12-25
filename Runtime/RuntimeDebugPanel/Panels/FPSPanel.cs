using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Illumate.RuntimeDebugPanel
{
    public class FPSPanel : RDPPanel
    {
        [SerializeField] private TMP_Text fpsText;
        [SerializeField] private Button smoothToggleButton;
        [SerializeField] private TMP_Text smoothToggleText;
        [Header("Target Frame Buttons")]
        [SerializeField] private Button targetFrameInfButton;
        [SerializeField] private Button targetFrame60Button;
        [SerializeField] private Button targetFrame30Button;

        private bool smoothView = false;
        private float fps;

        private void OnEnable()
        {
            smoothToggleButton.onClick.AddListener(SmoothViewToggle);
            targetFrameInfButton.onClick.AddListener(() => { SetFrame(999); });
            targetFrame60Button.onClick.AddListener(() => { SetFrame(60); });
            targetFrame30Button.onClick.AddListener(() => { SetFrame(30); });
        }

        private void Update()
        {
            if (smoothView)
            {
                fps = smoothView ? Mathf.Lerp(fps, 1.0f / Time.deltaTime, Time.deltaTime * 20) : 1.0f/Time.deltaTime;
            }
            fpsText.text = "FPS: " + fps.ToString("F1");
        }

        private void SetFrame(int frame)
        {
            Application.targetFrameRate = frame;
        }
        private void SmoothViewToggle()
        {
            smoothView = !smoothView;
            smoothToggleText.text = smoothView ? "-" : "~";
        }
    }
}

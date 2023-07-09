using UnityEngine;

namespace Illumate.Helper
{
    public class GetScreenShoot : MonoBehaviour
    {
        [SerializeField] private KeyCode ScreenshotButton = KeyCode.S;

        private static int captureCount
        {
            get { return PlayerPrefs.GetInt("ScreenshotCaptureStep", 0); }
            set { PlayerPrefs.SetInt("ScreenshotCaptureStep", value); }
        }

        private void Update()
        {
            if (Input.GetKeyDown(ScreenshotButton))
            {
                ScreenCapture.CaptureScreenshot("Recordings/Capture-" + captureCount + ".png");
                captureCount++;
                Debug.Log("Screen Captured");
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Illumate.Helper
{
    public class FrameController : MonoBehaviour
    {
        [SerializeField, Range(1, 200)] private int Fps = 60;

        private void OnValidate()
        {
            Application.targetFrameRate = Fps;
        }
    }
}

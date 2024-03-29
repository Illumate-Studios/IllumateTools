using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Illumate.Tools
{
    public static class TemporaryFloatFix
    {
        public static float StringToFloat(string s)
        {
            s = s.Replace(',', '.');
            string beforeDot = s.Split('.')[0];
            string afterDot = s.Split(".").Length == 2 ? s.Split(".")[1] : "0";
            return int.Parse(beforeDot) + int.Parse(afterDot) * Mathf.Pow(10, -afterDot.Length);
        }
        public static string FloatToString(float f)
        {
            throw new System.NotImplementedException();
            //int beforeDot = Mathf.CeilToInt(f);   
            //string afterDotStr = (f - beforeDot).ToString();
            //afterDotStr = afterDotStr.Replace(',', '.');
            //var afterDotSplit = afterDotStr.Split('.');
            //int afterDot = afterDotSplit.Length == 2 ? int.Parse(afterDotSplit[1]) : 0;
            //return beforeDot.ToString() + "." + afterDot.ToString();
        }
    }
}

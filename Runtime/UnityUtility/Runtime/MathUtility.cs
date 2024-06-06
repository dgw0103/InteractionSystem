using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityUtility
{
    public static class MathUtility
    {
        public static float RoundAt(this float value, int at)
        {
            return Mathf.Round(value * Mathf.Pow(10f, at)) * Mathf.Pow(0.1f, at);
        }
    }
}

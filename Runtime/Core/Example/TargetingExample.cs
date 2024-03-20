using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoJin.InteractionSystem
{
    public class TargetingExample : Targeting
    {
        public override void OnTargeted()
        {
            Debug.Log("Targeted");
        }
        public override void OnReleased()
        {
            Debug.Log("Released");
        }
    }
}
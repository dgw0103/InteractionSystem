using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoJin.InteractionSystem
{
    public class DefaultTargeting : Targeting
    {
        public override void OnTargeted()
        {
            Debug.Log(nameof(OnTargeted));
        }
        public override void OnReleased()
        {
            Debug.Log(nameof(OnReleased));
        }
    }
}
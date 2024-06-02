using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoJin.InteractionSystem
{
    public interface ITargeting
    {
        public void OnTargeted();
        public void OnReleased();
    }
}
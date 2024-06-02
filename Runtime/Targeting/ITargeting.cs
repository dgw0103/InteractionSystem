using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractionSystem
{
    public interface ITargeting
    {
        public void OnTargeted();
        public void OnReleased();
    }
}
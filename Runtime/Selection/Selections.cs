using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HoJin.InteractionSystem
{
    public abstract class Selections : MonoBehaviour
    {
        public abstract void SetAsThisTypeState(Selector selector);
        public abstract void UnsetAsThisTypeState(Selector selector);
        public abstract void OnSelect(Selector selector);
        public abstract void OnUnselect(Selector selector);
    }
}
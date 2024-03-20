using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HoJin.InteractionSystem
{
    public abstract class Selections : MonoBehaviour
    {
        public void Select(Selector selector)
        {
            Stack<Selections> currentSelections = selector.CurrentSelections;



            if (currentSelections.TryPeek(out Selections last))
            {
                if (last.GetType().Equals(GetType()) == false)
                {
                    last.UnsetAsThisTypeState();
                    SetAsThisTypeState(selector);
                }
            }
            else
            {
                SetAsThisTypeState(selector);
                selector.EnableUnselectionAction();
            }
            currentSelections.Push(this);
            OnSelect(selector);
        }
        public void Unselect(Selector selector)
        {
            Stack<Selections> currentSelections = selector.CurrentSelections;



            OnUnselect();
            currentSelections.Pop();
            if (currentSelections.TryPeek(out Selections last))
            {
                if (last.GetType().Equals(GetType()) == false)
                {
                    UnsetAsThisTypeState();
                    last.SetAsThisTypeState(selector);
                }
            }
            else
            {
                UnsetAsThisTypeState();
                selector.DisableUnselectionAction();
            }
        }
        protected abstract void SetAsThisTypeState(Selector selector);
        protected abstract void UnsetAsThisTypeState();
        protected abstract void OnSelect(Selector selector);
        protected abstract void OnUnselect();
    }
}
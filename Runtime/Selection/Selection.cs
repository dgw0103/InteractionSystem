using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InteractionSystem
{
    public abstract class Selection : MonoBehaviour
    {
        private Action onDisable;



        protected void OnDestroy()
        {
            onDisable?.Invoke();
        }



        internal void Select(Selector selector)
        {
            if (selector.TryGetRecentSelection(out Selection recentSelection))
            {
                if (recentSelection.GetType().Equals(GetType()) == false)
                {
                    recentSelection.UnsetAsThisTypeState(selector);
                    SetAsThisTypeState(selector);
                }
            }
            else
            {
                SetAsThisTypeState(selector);
                selector.enabled = true;
            }

            OnSelect(selector);
            onDisable = Unselect;





            void Unselect()
            {
                this.Unselect(selector);
            }
        }
        internal void Unselect(Selector selector)
        {
            OnUnselect(selector);
            onDisable = null;

            if (selector.TryGetRecentSelection(out Selection recentSelection))
            {
                if (recentSelection.GetType().Equals(GetType()) == false)
                {
                    UnsetAsThisTypeState(selector);
                    recentSelection.SetAsThisTypeState(selector);
                }
            }
            else
            {
                UnsetAsThisTypeState(selector);
            }
        }
        protected abstract void SetAsThisTypeState(Selector selector);
        protected abstract void UnsetAsThisTypeState(Selector selector);
        protected abstract void OnSelect(Selector selector);
        protected abstract void OnUnselect(Selector selector);
    }
}
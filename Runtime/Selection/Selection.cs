using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InteractionSystem
{
    public abstract class Selection : MonoBehaviour
    {
        private Selector selector;
        public event Action onPreSelected;
        public event Action onPostSelected;
        public event Action onPreUnselected;
        public event Action onPostUnselected;



        protected void OnDestroy()
        {
            OnPostUnselected();
        }



        internal void OnPreSelectedForSelector(Selector selector)
        {
            this.selector = selector;
            OnPreSelected();
            onPreSelected?.Invoke();
        }
        internal void OnPostSelectedForSelector()
        {
            OnPostSelected();
            onPostSelected?.Invoke();
        }
        internal void OnPreUnselectedForSelector()
        {
            OnPreUnselected();
            onPreUnselected?.Invoke();
        }
        internal void OnPostUnselectedForSelector()
        {
            OnPostUnselected();
            onPostUnselected?.Invoke();
            selector = null;
        }
        protected virtual void OnPreSelected()
        {

        }
        protected virtual void OnPostSelected()
        {

        }
        protected virtual void OnPreUnselected()
        {

        }
        protected virtual void OnPostUnselected()
        {

        }
        protected Selector Selector { get => selector; }
    }
}
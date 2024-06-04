using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace InteractionSystem
{
    [AddComponentMenu(nameof(InteractionSystem) + "/" + nameof(Selector))]
    public class Selector : MonoBehaviour
    {
        [SerializeField] private SelectionInput selectionInput;
        private Stack<Selection> currentSelections = new Stack<Selection>();



        private void Awake()
        {
            selectionInput.Init(Unselect);





            void Unselect()
            {
                if (TryGetRecentSelection(out Selection selection))
                {
                    this.Unselect(selection);
                }
            }
        }
        private void OnEnable()
        {
            selectionInput.EnableUnselectionAction();
        }
        private void OnDisable()
        {
            selectionInput.DisableUnselectionAction();
            while (currentSelections.TryPeek(out Selection selection) && selection)
            {
                UnselectForce(selection);
            }
        }



        public void Select(Selection selection)
        {
            if (enabled)
            {
                selection.Select(this);
                currentSelections.Push(selection);
            }
        }
        public void Unselect(Selection selection)
        {
            if (enabled)
            {
                UnselectForce(selection);
            }
        }
        private void UnselectForce(Selection selection)
        {
            currentSelections.Pop();
            selection.Unselect(this);
        }
        internal bool TryGetRecentSelection(out Selection selection)
        {
            return currentSelections.TryPeek(out selection);
        }
    }
}
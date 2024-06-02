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
        }
        private void OnEnable()
        {
            selectionInput.EnableUnselectionAction();
        }
        private void OnDisable()
        {
            selectionInput.DisableUnselectionAction();
        }



        public void Select(Selection selection)
        {
            if (currentSelections.TryPeek(out Selection last))
            {
                if (last.GetType().Equals(GetType()) == false)
                {
                    last.UnsetAsThisTypeState(this);
                    selection.SetAsThisTypeState(this);
                }
            }
            else
            {
                selection.SetAsThisTypeState(this);
                EnableUnselectionAction();
            }
            currentSelections.Push(selection);
            selection.OnSelect(this);
        }
        public void Unselect(Selection selection)
        {
            selection.OnUnselect(this);
            currentSelections.Pop();
            if (currentSelections.TryPeek(out Selection last))
            {
                if (last.GetType().Equals(GetType()) == false)
                {
                    selection.UnsetAsThisTypeState(this);
                    last.SetAsThisTypeState(this);
                }
            }
            else
            {
                selection.UnsetAsThisTypeState(this);
                DisableUnselectionAction();
            }
        }
        private void Unselect()
        {
            if (currentSelections.TryPeek(out Selection selection))
            {
                Unselect(selection);
            }
        }
        private void EnableUnselectionAction()
        {
            selectionInput.EnableUnselectionAction();
        }
        private void DisableUnselectionAction()
        {
            selectionInput.DisableUnselectionAction();
        }
    }
}
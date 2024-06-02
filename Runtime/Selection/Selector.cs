using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace HoJin.InteractionSystem
{
    public class Selector : MonoBehaviour
    {
        [SerializeField] private SelectionsInput selectionsInput;
        private Stack<Selections> currentSelections = new Stack<Selections>();



        private void Awake()
        {
            selectionsInput.Init(Unselect);
        }



        public void Select(Selections selection)
        {
            if (currentSelections.TryPeek(out Selections last))
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
        public void Unselect(Selections selection)
        {
            selection.OnUnselect(this);
            currentSelections.Pop();
            if (currentSelections.TryPeek(out Selections last))
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
            if (currentSelections.TryPeek(out Selections selection))
            {
                Unselect(selection);
            }
        }
        public Stack<Selections> CurrentSelections { get => currentSelections; }
        public void EnableUnselectionAction()
        {
            selectionsInput.EnableUnselectionAction();
        }
        public void DisableUnselectionAction()
        {
            selectionsInput.DisableUnselectionAction();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace HoJin.InteractionSystem
{
    [RequireComponent(typeof(Interactor))]
    public class Selector : MonoBehaviour
    {
        [SerializeField] private SelectionsInput selectionsInput;
        private Stack<Selections> currentSelections = new Stack<Selections>();



        private void Awake()
        {
            selectionsInput.Init(Unselect);
        }



        private void Unselect()
        {
            if (currentSelections.TryPeek(out Selections selections))
            {
                selections.Unselect(this);
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
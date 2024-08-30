using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace InteractionSystem
{
    [AddComponentMenu(nameof(InteractionSystem) + "/" + nameof(Selector))]
    public class Selector : MonoBehaviour
    {
        private SelectionInput selectionInput;
        private Stack<Selection> currentSelections = new Stack<Selection>();



        private void Awake()
        {
            selectionInput = new SelectionInput(Unselect);





            void Unselect()
            {
                if (currentSelections.TryPeek(out Selection selection))
                {
                    this.Unselect(selection);
                }
            }
        }
        private void OnEnable()
        {
            selectionInput.EnableAction();
        }
        private void OnDisable()
        {
            selectionInput.DisableAction();
            while (currentSelections.TryPeek(out Selection selection) && selection)
            {
                UnselectForce(selection);
            }
        }



        public void Select(Selection selection)
        {
            if (enabled)
            {
                selection.OnPreSelectedForSelector(this);
                if (currentSelections.Count == 0)
                {
                    selectionInput.EnableAction();
                    EnabledPlayerMoving = false;
                }
                currentSelections.Push(selection);
                selection.OnPostSelectedForSelector();
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
            selection.OnPreUnselectedForSelector();
            currentSelections.Pop();
            if (currentSelections.Count == 0)
            {
                selectionInput.DisableAction();
                EnabledPlayerMoving = true;
            }
            selection.OnPostUnselectedForSelector();
        }
        public Selection LatestSelection
        {
            get
            {
                Selection selection = null;

                currentSelections.TryPeek(out selection);

                return selection;
            }
        }
        private bool EnabledPlayerMoving
        {
            set
            {
                if (TryGetComponent(out IPlayerMoving playerMoving))
                {
                    playerMoving.Enabled = value;
                }
                else
                {
                    Debug.LogWarning($"Selector GameObject has not {nameof(IPlayerMoving)} component");
                }
            }
        }
    }
}
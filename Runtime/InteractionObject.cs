using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace HoJin.InteractionSystem
{
    public class InteractionObject : MonoBehaviour
    {
        private Targeting[] targetings;
        private IInteractionEvent interactionEvent;




        private void Awake()
        {
            targetings = GetComponents<Targeting>().OrderBy((x) => x.Priority).ToArray();
            if (TryGetComponent(out interactionEvent) == false)
            {
                interactionEvent = new DefaultInteractionEvent();
            }
        }



        public void OnTargeted()
        {
            foreach (var item in targetings)
            {
                item.OnTargeted();
            }
        }
        public void OnReleased()
        {
            foreach (var item in targetings)
            {
                item.OnReleased();
            }
        }
        public IInteractionEvent InteractionEvent { get => interactionEvent; }
    }
}
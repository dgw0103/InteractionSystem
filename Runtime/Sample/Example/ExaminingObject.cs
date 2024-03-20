using System;
using System.Linq;
using UnityEngine;

namespace HoJin.InteractionSystem
{
    public class ExaminingObject : InteractionObject
    {
        private Examining examining;

        

        private new void Awake()
        {
            base.Awake();
            TryGetComponent(out examining);
        }



        public override void OnInteractionStarted(Interactor interactor)
        {

        }
        public override void OnInteractionPerformed(Interactor interactor)
        {
            if (interactor.TryGetComponent(out Selector selector))
            {
                examining.Select(selector);
            }
        }
        public override void OnInteractionCanceled(Interactor interactor)
        {

        }
    }
}
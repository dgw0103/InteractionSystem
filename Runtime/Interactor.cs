using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoJin.InteractionSystem
{
    public class Interactor : MonoBehaviour
    {
        [SerializeField] private float maxDistance = 1.5f;
        [SerializeField] private LayerMask interactionLayerMask;
        [SerializeField] private LayerMask blockingLayerMask;
        private InteractionObject currentTarget = null;



        private void OnEnable()
        {
            if (currentTarget)
            {
                OnRelease();
                currentTarget = null;
            }
        }
        private void Update()
        {
            #region update target
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, maxDistance, interactionLayerMask | blockingLayerMask) &&
                (interactionLayerMask | LayerMask.GetMask(LayerMask.LayerToName(hit.collider.gameObject.layer))).Equals(interactionLayerMask) &&
                hit.collider.gameObject.TryGetComponent(out InteractionObject target))
            {
                if (target.Equals(currentTarget) == false)
                {
                    TryNoLookAt();
                    currentTarget = target;
                    OnTarget();
                }
            }
            else if (currentTarget == null)
            {
                currentTarget = null;
            }
            else
            {
                if (TryNoLookAt())
                {
                    currentTarget = null;
                }
            }





            bool TryNoLookAt()
            {
                if (currentTarget != null)
                {
                    currentTarget.OnReleased();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            #endregion
        }



        private void OnTarget()
        {
            currentTarget.OnTargeted();
        }
        private void OnRelease()
        {
            currentTarget.OnReleased();
        }
        public void PauseInteracting()
        {
            enabled = false;
        }
        public void ResumeInteracting()
        {
            enabled = true;
        }
        public void OnInteractionStarted()
        {
            currentTarget.InteractionEvent.OnStarted(this);
        }
        public void OnInteractionPerformed()
        {
            currentTarget.InteractionEvent.OnPerformed(this);
        }
        public void OnInteractionCanceled()
        {
            currentTarget.InteractionEvent.OnCanceled(this);
        }
    }
}
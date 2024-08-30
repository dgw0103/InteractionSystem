using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractionSystem
{
    [AddComponentMenu(nameof(InteractionSystem) + "/" + nameof(Interactor))]
    public class Interactor : MonoBehaviour
    {
        [SerializeField] private Transform rayShooter;
        [SerializeField] private float maxDistance = 1.5f;
        private InteractionInput interactionInput;
        private InteractionObject currentTarget = null;



        private void Awake()
        {
            interactionInput = new InteractionInput(OnStarted, OnPerformed, OnCanceled);
            interactionInput.EnableAction();
            




            void OnStarted()
            {
                if (IsInteractable)
                {
                    currentTarget.OnInteractionStarted(this);
                }
            }
            void OnPerformed()
            {
                if (IsInteractable)
                {
                    currentTarget.OnInteractionPerformed(this);
                }
            }
            void OnCanceled()
            {
                if (IsInteractable)
                {
                    currentTarget.OnInteractionCanceled(this);
                }
            }
        }
        private void OnEnable()
        {
            if (IsInteractable)
            {
                OnRelease();
                CurrentTarget = null;
            }
            interactionInput.EnableAction();
        }
        private void Update()
        {
            #region update target
            InteractionSystemGlobalData.InteractionSystemData interactionSystemData = InteractionSystemGlobalData.InteractionSystemDataInstance;
            LayerMask interactionLayerMask = interactionSystemData.InteractionLayerMask;
            LayerMask blockingLayerMask = interactionSystemData.BlockingLayerMask;



            if (Raycast(out RaycastHit hit) && IsRayHitAtInteractable() && hit.transform.gameObject.TryGetComponent(out InteractionObject target))
            {
                if (target.Equals(currentTarget) == false)
                {
                    OnRelease();
                    CurrentTarget = target;
                }
                OnTarget();
            }
            else
            {
                if (HasCurrentTarget)
                {
                    OnRelease();
                    CurrentTarget = null;
                }
            }





            bool Raycast(out RaycastHit raycastHit)
            {
                return Physics.Raycast(rayShooter.position, rayShooter.forward, out raycastHit, maxDistance, interactionLayerMask | blockingLayerMask);
            }
            bool IsRayHitAtInteractable()
            {
                return (interactionLayerMask | LayerMask.GetMask(LayerMask.LayerToName(hit.collider.gameObject.layer))).Equals(interactionLayerMask);
            }
            #endregion
        }
        private void OnDisable()
        {
            interactionInput.DisableAction();
            CurrentTarget = null;
        }



        private InteractionObject CurrentTarget { set => currentTarget = value; }
        private bool IsInteractable { get => HasCurrentTarget && currentTarget.enabled; }
        private bool HasCurrentTarget { get => currentTarget; }
        private bool IsTargetable(out Targeting targeting)
        {
            if (HasCurrentTarget)
            {
                return currentTarget.TryGetComponent(out targeting) && targeting.Enabled;
            }
            else
            {
                targeting = null;
                return false;
            }
        }
        private void OnTarget()
        {
            if (IsTargetable(out Targeting targeting))
            {
                targeting.OnTargeted();
            }
        }
        private void OnRelease()
        {
            if (IsTargetable(out Targeting targeting))
            {
                targeting.OnReleased();
            }
        }
    }
}
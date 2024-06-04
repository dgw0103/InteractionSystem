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
        [SerializeField] private InteractionInput interactionInput;
        [SerializeField] private InteractionSystemData interactionSystemData;
        [SerializeField] private float maxDistance = 1.5f;
        private InteractionObject currentTarget = null;
        public event Action<InteractionObject> OnInteraction;



        private void Awake()
        {
            interactionInput.Init(OnStarted, OnPerformed, OnCanceled);
            interactionInput.EnableInteractionAction();
            




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
                    OnInteraction?.Invoke(currentTarget);
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
            interactionInput.EnableInteractionAction();
        }
        private void Update()
        {
            #region update target
            LayerMask interactionLayerMask = interactionSystemData.interactionLayerMask;
            LayerMask blockingLayerMask = interactionSystemData.blockingLayerMask;



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
            interactionInput.DisableInteractionAction();
            CurrentTarget = null;
        }



        private InteractionObject CurrentTarget { set => currentTarget = value; }
        private bool IsInteractable { get => HasCurrentTarget && currentTarget.Enabled; }
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
        public float MaxDistance { get => maxDistance; }
    }
}
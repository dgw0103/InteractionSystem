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
                if (HasCurrentTarget)
                {
                    currentTarget.OnInteractionStarted(this);
                }
            }
            void OnPerformed()
            {
                if (HasCurrentTarget)
                {
                    currentTarget.OnInteractionPerformed(this);
                    OnInteraction?.Invoke(currentTarget);
                }
            }
            void OnCanceled()
            {
                if (HasCurrentTarget)
                {
                    currentTarget.OnInteractionCanceled(this);
                }
            }
        }
        private void OnEnable()
        {
            if (HasCurrentTarget)
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



            if (Physics.Raycast(rayShooter.position, rayShooter.forward, out RaycastHit hit, maxDistance, interactionLayerMask | blockingLayerMask) &&
                (interactionLayerMask | LayerMask.GetMask(LayerMask.LayerToName(hit.collider.gameObject.layer))).Equals(interactionLayerMask) &&
                hit.collider.gameObject.TryGetComponent(out InteractionObject target))
            {
                if (target.Equals(currentTarget) == false)
                {
                    TryNoLookAt();
                    CurrentTarget = target;
                    OnTarget();
                }
            }
            else if (HasCurrentTarget == false)
            {
                CurrentTarget = null;
            }
            else
            {
                if (TryNoLookAt())
                {
                    CurrentTarget = null;
                }
            }





            bool TryNoLookAt()
            {
                if (HasCurrentTarget && currentTarget.TryGetComponent(out ITargeting targeting))
                {
                    targeting.OnReleased();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            #endregion
        }
        private void OnDisable()
        {
            interactionInput.DisableInteractionAction();
        }



        private InteractionObject CurrentTarget { set => currentTarget = value; }
        private bool HasCurrentTarget { get => currentTarget; }
        private void OnTarget()
        {
            if (HasCurrentTarget && currentTarget.TryGetComponent(out ITargeting targeting))
            {
                targeting.OnTargeted();
            }
        }
        private void OnRelease()
        {
            if (HasCurrentTarget && currentTarget.TryGetComponent(out ITargeting targeting))
            {
                targeting.OnReleased();
            }
        }
        public float MaxDistance { get => maxDistance; }
    }
}
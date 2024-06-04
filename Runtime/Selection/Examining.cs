using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractionSystem
{
    [AddComponentMenu(nameof(InteractionSystem) + "/" + nameof(Examining))]
    public class Examining : Selection
    {
        [SerializeField] private AudioSource pickUpSound;
        [SerializeField] private float distanceOffset;
        [SerializeField] private Vector3 positionOffset;
        [SerializeField] private Vector3 rotationOffset;
        [SerializeField] private bool isMoveImmediately = false;
        private Coroutine comingCoroutine;
        private Collider[] colliders;
        private bool[] previousIsTrigger;
        private Vector3 previousLocalPosition;
        private Quaternion previousLocalRotation;
        private int previousLayer;
        private const float comingSpeed = 5f;



        protected override void SetAsThisTypeState(Selector selector)
        {
            EnabledPlayerMoving(selector, false);
        }
        private bool EnabledInteractableAndTargetable
        {
            set
            {
                if (TryGetComponent(out InteractionObject interactionObject))
                {
                    interactionObject.enabled = value;
                }
                if (TryGetComponent(out Targeting targeting))
                {
                    targeting.Enabled = value;
                }
            }
        }
        private void EnabledPlayerMoving(Selector selector, bool value)
        {
            if (selector.TryGetComponent(out IPlayerMoving playerMoving))
            {
                playerMoving.Enabled = value;
            }
            else
            {
                Debug.LogWarning($"Selector GameObject has not {nameof(IPlayerMoving)} component");
            }
        }
        protected override void UnsetAsThisTypeState(Selector selector)
        {
            EnabledPlayerMoving(selector, true);
        }
        protected override void OnSelect(Selector selector)
        {
            OnSelect(selector.transform);
        }
        private void OnSelect(Transform selector)
        {
            if (pickUpSound)
            {
                pickUpSound.Play();
            }

            previousLocalPosition = transform.localPosition;
            previousLocalRotation = transform.localRotation;

            #region Moving
            comingCoroutine = StartCoroutine(Move());





            IEnumerator Move()
            {
                while (this)
                {
                    Vector3 targetPosition = selector.position + (selector.forward * distanceOffset) + positionOffset;

                    transform.position = isMoveImmediately ? targetPosition : Vector3.Lerp(transform.position, targetPosition, comingSpeed * Time.deltaTime);
                    LookAt();
                    yield return null;
                }
            }
            void LookAt()
            {
                transform.LookAt((transform.position) + selector.forward, selector.up);
                transform.localRotation *= Quaternion.Euler(rotationOffset);
            }
            #endregion

            colliders = GetComponentsInChildren<Collider>();
            previousIsTrigger = new bool[colliders.Length];
            for (int i = 0; i < previousIsTrigger.Length; i++)
            {
                if (colliders[i])
                {
                    previousIsTrigger[i] = colliders[i].isTrigger;
                    colliders[i].isTrigger = true;
                }
            }

            previousLayer = gameObject.layer;

            EnabledInteractableAndTargetable = false;
        }
        protected override void OnUnselect(Selector selector)
        {
            transform.localPosition = previousLocalPosition;
            transform.localRotation = previousLocalRotation;

            if (comingCoroutine != null)
            {
                StopCoroutine(comingCoroutine);
            }

            for (int i = 0; i < previousIsTrigger.Length; i++)
            {
                if (colliders[i])
                {
                    colliders[i].isTrigger = previousIsTrigger[i];
                }
            }

            gameObject.layer = previousLayer;

            EnabledInteractableAndTargetable = true;
        }
    }
}
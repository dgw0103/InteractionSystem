using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractionSystem
{
    [AddComponentMenu(nameof(InteractionSystem) + "/" + nameof(Examination))]
    public class Examination : Selection
    {
        [SerializeField] private AudioSource pickUpSound;
        [SerializeField] private float distanceOffset;
        [SerializeField] private Vector3 positionOffset;
        [SerializeField] private Vector3 rotationOffset;
        [SerializeField] private bool isMoveImmediately = false;
        private Coroutine comingCoroutine;
        private Collider[] colliders;
        private bool[] previousIsTriggers = new bool[0];
        private Vector3 previousLocalPosition;
        private Quaternion previousLocalRotation;
        private int previousLayer;
        private const float comingSpeed = 5f;



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
        protected override void OnPostSelected()
        {
            if (pickUpSound)
            {
                pickUpSound.Play();
            }

            previousLocalPosition = transform.localPosition;
            previousLocalRotation = transform.localRotation;

            #region Moving
            Transform selector = Selector.transform;
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
            previousIsTriggers = new bool[colliders.Length];
            for (int i = 0; i < previousIsTriggers.Length; i++)
            {
                if (colliders[i])
                {
                    previousIsTriggers[i] = colliders[i].isTrigger;
                    colliders[i].isTrigger = true;
                }
            }

            previousLayer = gameObject.layer;

            EnabledInteractableAndTargetable = false;
        }
        protected override void OnPostUnselected()
        {
            transform.localPosition = previousLocalPosition;
            transform.localRotation = previousLocalRotation;

            if (comingCoroutine != null)
            {
                StopCoroutine(comingCoroutine);
            }

            for (int i = 0; i < previousIsTriggers.Length; i++)
            {
                if (colliders[i])
                {
                    colliders[i].isTrigger = previousIsTriggers[i];
                }
            }

            gameObject.layer = previousLayer;

            EnabledInteractableAndTargetable = true;
        }
        internal protected float DistanceOffset { get => distanceOffset; set => distanceOffset = value; }
        internal protected Quaternion RotationOffset { get => Quaternion.Euler(rotationOffset); set => rotationOffset = value.eulerAngles; }
    }
}
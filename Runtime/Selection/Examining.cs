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
        [SerializeField] private float examiningDistance;
        [SerializeField] private Vector3 examiningAngle;
        [SerializeField] private bool isMoveImmediately = false;
        private Coroutine comingCoroutine;
        private Collider[] colliders;
        private bool[] previousIsTrigger;
        private Vector3 previousLocalPosition;
        private Quaternion previousLocalRotation;
        private int previousLayer;
        private readonly float comingSpeed = 5f;



        public override void SetAsThisTypeState(Selector selector)
        {
            EnabledPlayerMoving(selector, false);
            EnabledInteractableAndTargetable = false;
        }
        private bool EnabledInteractableAndTargetable
        {
            set
            {
                if (TryGetComponent(out InteractionObject interactionObject))
                {
                    interactionObject.Enabled = value;
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
        public override void UnsetAsThisTypeState(Selector selector)
        {
            EnabledPlayerMoving(selector, true);
            EnabledInteractableAndTargetable = true;
        }
        public override void OnSelect(Selector selector)
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

            #region move for examining
            if (isMoveImmediately)
            {
                comingCoroutine = StartCoroutine(MoveImmediatelyToPlayer());



                IEnumerator MoveImmediatelyToPlayer()
                {
                    while (this)
                    {
                        transform.position = selector.position + (selector.forward * examiningDistance);
                        LookAtCamera();

                        yield return null;
                    }
                }
            }
            else
            {
                comingCoroutine = StartCoroutine(MoveSmoothly());



                IEnumerator MoveSmoothly()
                {
                    while (this)
                    {
                        transform.position =
                            Vector3.Lerp(transform.position, selector.position + (selector.forward * examiningDistance),
                            comingSpeed * Time.deltaTime);
                        LookAtCamera();
                        yield return null;
                    }
                }
            }
            LookAtCamera();





            void LookAtCamera()
            {
                transform.LookAt((transform.position) + selector.forward, selector.up);
                Quaternion localRotation = transform.localRotation;
                transform.localRotation = localRotation * Quaternion.Euler(examiningAngle);
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
        }
        public override void OnUnselect(Selector selector)
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
        }
    }
}
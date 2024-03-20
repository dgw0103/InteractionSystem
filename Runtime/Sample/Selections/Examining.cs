using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoJin.InteractionSystem
{
    public class Examining : Selections
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
        protected override void OnUnselect()
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
        protected override void SetAsThisTypeState(Selector selector)
        {
            if (selector.TryGetComponent(out CharacterMoving characterMoving))
            {
                characterMoving.EnableMoving();
            }
            else
            {
                Debug.LogWarning($"No {nameof(CharacterMoving)} component in interactor object");
            }
            if (selector.TryGetComponent(out CameraMoving cameraMoving))
            {
                cameraMoving.EnableMoving();
            }
            else
            {
                Debug.LogWarning($"No {nameof(CameraMoving)} component in interactor object");
            }
        }
        protected override void UnsetAsThisTypeState()
        {
        }
    }
}
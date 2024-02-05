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
        private float originalExaminingDistance;
        private Collider[] colliders;
        private Coroutine comingCoroutine;
        private Vector3 originalLocalPosition;
        private Quaternion originalLocalRotation;
        private readonly float comingSpeed = 5f;



        protected void Awake()
        {
            colliders = GetComponents<Collider>();
            originalExaminingDistance = examiningDistance;
        }



        public override void OnSelectionAtFirst(Interactor interactor)
        {
            base.OnSelectionAtFirst(interactor);
            if (pickUpSound)
            {
                pickUpSound.Play();
            }

            #region move for examining
            if (isMoveImmediately)
            {
                comingCoroutine = StartCoroutine(MoveImmediatelyToPlayer());



                IEnumerator MoveImmediatelyToPlayer()
                {
                    while (this)
                    {
                        transform.position = interactor.transform.position + (interactor.transform.forward * examiningDistance);
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
                        transform.position = Vector3.Lerp(transform.position, interactor.transform.position + (interactor.transform.forward * examiningDistance),
                            comingSpeed * Time.deltaTime);
                        LookAtCamera();
                        yield return null;
                    }
                }
            }
            LookAtCamera();
            #endregion

            UpdateOriginalTransform();





            void LookAtCamera()
            {
                transform.LookAt((transform.position) + interactor.transform.forward, interactor.transform.up);
                Quaternion localRotation = transform.localRotation;
                transform.localRotation = localRotation * Quaternion.Euler(examiningAngle);
            }
        }
        protected override void OnSelection(Interactor interactor)
        {
            examiningDistance = originalExaminingDistance;
            foreach (var item in colliders)
            {
                if (item)
                {
                    item.isTrigger = true;
                }
            }
        }
        public override void OnUnselectionAtFirst(Interactor interactor)
        {
            base.OnUnselectionAtFirst(interactor);
            transform.localPosition = originalLocalPosition;
            transform.localRotation = originalLocalRotation;
            if (ReferenceEquals(comingCoroutine, null) == false)
            {
                StopCoroutine(comingCoroutine);
            }
        }
        protected override void OnUnselection(Interactor interactor)
        {
            foreach (var item in colliders)
            {
                if (item)
                {
                    item.isTrigger = false;
                }
            }
        }
        private void UpdateOriginalTransform()
        {
            originalLocalPosition = transform.localPosition;
            originalLocalRotation = transform.localRotation;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace InteractionSystem
{
    public class DetailedExamination : Examination
    {
        [SerializeField] private float minDistance;
        [SerializeField] private float maxDistance;
        private DetailedExaminationInput detailedExaminationInput;
        private float originalDistanceOffset;
        private Quaternion originalRotationOffset;
        public event Action<Vector2> OnRotate;
        public event Action<float> OnZoomInOut;



        private void Awake()
        {
            detailedExaminationInput = new DetailedExaminationInput(Rotate, ZoomInZoomOut);
        }



        protected override void OnPreSelected()
        {
            base.OnPreSelected();

            Selection latestSelection = Selector?.LatestSelection;
            if (latestSelection && latestSelection is DetailedExamination)
            {
                (latestSelection as DetailedExamination).detailedExaminationInput.DisableAction();
            }



            originalDistanceOffset = DistanceOffset;
            originalRotationOffset = RotationOffset;

            detailedExaminationInput.EnableAction();
        }
        protected override void OnPostUnselected()
        {
            base.OnPostUnselected();

            Selection latestSelection = Selector?.LatestSelection;
            if (latestSelection && latestSelection is DetailedExamination)
            {
                (latestSelection as DetailedExamination).detailedExaminationInput.EnableAction();
            }




            DistanceOffset = originalDistanceOffset;
            RotationOffset = originalRotationOffset;

            detailedExaminationInput.DisableAction();
        }
        private void Rotate(Vector2 value)
        {
            if (detailedExaminationInput.IsRotating == false)
            {
                return;
            }



            Vector2 rotationValue = InteractionSystemGlobalData.DetailedExaminationDataInstance.RotationSpeed * value;

            RotationOffset *= Quaternion.AngleAxis(-rotationValue.x, Quaternion.Inverse(transform.rotation) * Selector.transform.up);
            RotationOffset *= Quaternion.AngleAxis(rotationValue.y, Quaternion.Inverse(transform.rotation) * Selector.transform.right);

            OnRotate?.Invoke(value);
        }
        private void ZoomInZoomOut(float value)
        {
            float scrollDirection = value / Mathf.Abs(value);
            float afterValue = Mathf.Round(DistanceOffset + scrollDirection);



            if (afterValue >= minDistance && afterValue <= maxDistance)
            {
                DistanceOffset += scrollDirection;

                OnZoomInOut?.Invoke(value);
            }
        }
    }
}
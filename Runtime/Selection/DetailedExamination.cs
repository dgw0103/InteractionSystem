using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace InteractionSystem
{
    public class DetailedExamination : Examination
    {
        [SerializeField] private float zoomInOutSpeed = 1f;
        [SerializeField] private float minDistance;
        [SerializeField] private float maxDistance;
        private DetailedExaminationInput detailedExaminationInput;
        private float originalDistanceOffset;
        private Quaternion originalRotationOffset;



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
        }
        private void ZoomInZoomOut(float value)
        {
            float scrollDirection = value / Mathf.Abs(value);
            float scrollValue = scrollDirection * zoomInOutSpeed;
            float afterValue = RoundAt(DistanceOffset + scrollValue, 1);

            if (afterValue >= minDistance && afterValue <= maxDistance)
            {
                DistanceOffset += scrollValue;
            }





            float RoundAt(float value, int at)
            {
                return Mathf.Round(value * Mathf.Pow(10f, at)) * Mathf.Pow(0.1f, at);
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

namespace InteractionSystem
{
    public class InteractionSystemGlobalData : MonoBehaviour
    {
        [SerializeField] private InteractionSystemGlobalDataAsset interactionSystemGlobalDataAsset;
        private static InteractionSystemGlobalData instance;



        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(instance);
            }
            else
            {
                Destroy(gameObject);
            }
        }



        public static InteractionSystemData InteractionSystemDataInstance { get => instance?.interactionSystemGlobalDataAsset?.InteractionSystemData; }
        public static LightEmissionData LightEmissionDataInstance { get => instance?.interactionSystemGlobalDataAsset?.LightEmissionData; }
        public static SelectionData SelectionDataInstance { get => instance?.interactionSystemGlobalDataAsset?.SelectionData; }
        public static DetailedExaminationData DetailedExaminationDataInstance { get => instance?.interactionSystemGlobalDataAsset?.DetailedExaminationData; }





        [Serializable]
        public class InteractionSystemData
        {
            [SerializeField] private LayerMask interactionLayerMask;
            [SerializeField] private LayerMask blockingLayerMask;
            [SerializeField] private InputActionReference inputActionReference;



            public LayerMask InteractionLayerMask { get => interactionLayerMask; }
            public LayerMask BlockingLayerMask { get => blockingLayerMask; }
            public InputActionReference InputActionReference { get => inputActionReference; }
        }
        [Serializable]
        public class LightEmissionData
        {
            [SerializeField] private Color emissionColor;
            [SerializeField] private string emissionColorKeyword;



            public Color EmissionColor { get => emissionColor; }
            public string EmissionColorKeyword { get => emissionColorKeyword; }
        }
        [Serializable]
        public class SelectionData
        {
            [SerializeField] private InputActionReference unselectionActionReference;



            public InputActionReference UnselectionActionReference { get => unselectionActionReference; }
        }
        [Serializable]
        public class DetailedExaminationData
        {
            [SerializeField] private float rotationSpeed = 1f;
            [SerializeField] private InputActionReference rotationActivationActionReference;
            [SerializeField] private InputActionReference rotationActionReference;
            [SerializeField] private InputActionReference zoomInZoomOutActionReference;



            public float RotationSpeed { get => rotationSpeed; }
            public InputActionReference RotationActivationActionReference { get => rotationActivationActionReference; }
            public InputActionReference RotationActionReference { get => rotationActionReference; }
            public InputActionReference ZoomInZoomOutActionReference { get => zoomInZoomOutActionReference; }
        }
    }
}
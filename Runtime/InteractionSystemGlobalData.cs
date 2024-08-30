using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Linq;

namespace InteractionSystem
{
    public class InteractionSystemGlobalData : MonoBehaviour
    {
        [SerializeField] private InteractionSystemData interactionSystemData;
        [SerializeField] private LightEmissionData lightEmissionData;
        [SerializeField] private SelectionData selectionData;
        [SerializeField] private DetailedExaminationData detailedExaminationData;
        private static InteractionSystemGlobalData instance = null;



        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void InitInstance()
        {
            if (instance == null)
            {
                instance = FindObjectOfType<InteractionSystemGlobalData>(true);
                DontDestroyOnLoad(instance);
            }
            else
            {
                foreach (var item in FindObjectsOfType<InteractionSystemGlobalData>(true).Where((x) => x != instance))
                {
                    Destroy(item.gameObject);
                }
            }
        }



        public static InteractionSystemData InteractionSystemDataInstance { get => instance?.interactionSystemData; }
        public static LightEmissionData LightEmissionDataInstance { get => instance?.lightEmissionData; }
        public static SelectionData SelectionDataInstance { get => instance?.selectionData; }
        public static DetailedExaminationData DetailedExaminationDataInstance { get => instance?.detailedExaminationData; }





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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

namespace InteractionSystem
{
    public class InteractionSystemGlobalData : MonoBehaviour
    {
        [SerializeField] private InteractionSystemData interactionSystemData;
        [SerializeField] private SelectionData selectionData;
        [SerializeField] private DetailedExaminationData detailedExaminationData;
        private static InteractionSystemGlobalData instance = null;



        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void InitInstance()
        {
            InteractionSystemGlobalData[] interactionSystemGlobalDatas = FindObjectsOfType<InteractionSystemGlobalData>(true);

            if (interactionSystemGlobalDatas.Length == 0)
            {
                Debug.LogError("Please in Hierarchy window > right click > Interaction system global data prefab.");
                return;
            }

            if (interactionSystemGlobalDatas.Length > 1)
            {
                for (int i = 0; i < interactionSystemGlobalDatas.Length; i++)
                {
                    if (i == 0)
                    {
                        continue;
                    }

                    Destroy(interactionSystemGlobalDatas[i]);
                }
            }



            InteractionSystemGlobalData interactionSystemGlobalData = interactionSystemGlobalDatas[0];

            instance = interactionSystemGlobalData;
            DontDestroyOnLoad(instance);
        }
        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
            }
        }




        public static InteractionSystemData InteractionSystemDataInstance { get => instance?.interactionSystemData; }
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
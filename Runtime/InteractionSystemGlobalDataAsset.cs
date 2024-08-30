using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InteractionSystem.InteractionSystemGlobalData;

namespace InteractionSystem
{
    internal class InteractionSystemGlobalDataAsset : ScriptableObject
    {
        [SerializeField] private InteractionSystemData interactionSystemData;
        [SerializeField] private LightEmissionData lightEmissionData;
        [SerializeField] private SelectionData selectionData;
        [SerializeField] private DetailedExaminationData detailedExaminationData;



        internal InteractionSystemData InteractionSystemData { get => interactionSystemData; }
        internal LightEmissionData LightEmissionData { get => lightEmissionData; }
        internal SelectionData SelectionData { get => selectionData; }
        internal DetailedExaminationData DetailedExaminationData { get => detailedExaminationData; }
    }
}
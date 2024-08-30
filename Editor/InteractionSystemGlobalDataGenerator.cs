using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace InteractionSystemEditor
{
    public class InteractionSystemGlobalDataGenerator
    {
        private static readonly string prefabPath = AssetDatabase.GUIDToAssetPath(new GUID("82b6f9c750f135f4cb87afd7be53ad5a"));
        private static readonly string prefabName = "InteractionSystemGlobalDataPrefab";



        [MenuItem("GameObject/Interaction system global data prefab")]
        private static void GenerateInteractionSystemGlobalDataPrefab()
        {
            GameObject prefab = AssetDatabase.LoadAssetAtPath(prefabPath, typeof(GameObject)) as GameObject;
            GameObject instantiatedPrefab = Object.Instantiate(prefab);
            GameObject copiedPrefab = PrefabUtility.SaveAsPrefabAsset(instantiatedPrefab, $"Assets/{prefabName}.prefab");
            PrefabUtility.InstantiatePrefab(copiedPrefab);
            Object.DestroyImmediate(instantiatedPrefab);
        }
    }
}
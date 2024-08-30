using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace InteractionSystemEditor
{
    internal class InteractionSystemGlobalDataMenu
    {
        [MenuItem("GameObject/Interaction system global data")]
        private static void CreateInteractionSystemGlobalDataPrefab()
        {
            GUID prefabGUID = new GUID("82b6f9c750f135f4cb87afd7be53ad5a");
            GameObject prefab = AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(prefabGUID), typeof(GameObject)) as GameObject;
            GameObject instantiated = PrefabUtility.InstantiatePrefab(prefab) as GameObject;

            instantiated.transform.SetAsLastSibling();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using InteractionSystem;

namespace InteractionSystemEditor
{
    [CustomEditor(typeof(InteractionSystemGlobalData))]
    public class InteractionSystemGlobalDataEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            SerializedProperty asset = serializedObject.GetIterator();
            asset.NextVisible(true);
            asset.NextVisible(true);

            SerializedObject serializedAsset = new SerializedObject(asset.objectReferenceValue);
            SerializedProperty assetProperty = serializedAsset.GetIterator();
            assetProperty.NextVisible(true);

            serializedAsset.Update();
            while (assetProperty.NextVisible(false))
            {
                EditorGUILayout.PropertyField(assetProperty);
            }
            serializedAsset.ApplyModifiedProperties();

            serializedObject.ApplyModifiedProperties();
        }
    }
}
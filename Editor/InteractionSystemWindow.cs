using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using InteractionSystem;
using UnityEditor.UIElements;

namespace InteractionSystemEditor
{
    public class InteractionSystemWindow : EditorWindow
    {
        [SerializeField] private InteractionSystemData interactionSystemDataReference;
        private SerializedObject serializedObject;
        private const string interactionSystemSavingKey = nameof(InteractionSystem);



        private void OnEnable()
        {
            string data = EditorPrefs.GetString(interactionSystemSavingKey, JsonUtility.ToJson(this, false));
            JsonUtility.FromJsonOverwrite(data, this);
            if (interactionSystemDataReference)
            {
                serializedObject = new SerializedObject(interactionSystemDataReference);
            }
        }
        private void OnDisable()
        {
            string data = JsonUtility.ToJson(this, false);
            EditorPrefs.SetString(interactionSystemSavingKey, data);
        }
        private void OnGUI()
        {
            interactionSystemDataReference =
                    EditorGUILayout.ObjectField(interactionSystemDataReference, typeof(InteractionSystemData), false) as InteractionSystemData;

            if (interactionSystemDataReference)
            {
                if (serializedObject == null)
                {
                    serializedObject = new SerializedObject(interactionSystemDataReference);
                }

                serializedObject.Update();

                SerializedProperty serializedProperty = serializedObject.GetIterator();
                serializedProperty.NextVisible(true);
                while (serializedProperty.NextVisible(false))
                {
                    EditorGUILayout.PropertyField(serializedProperty);
                }

                serializedObject.ApplyModifiedProperties();
                Repaint();
            }
        }



        [MenuItem("Window/" + nameof(InteractionSystem))]
        private static void OpenWindow()
        {
            EditorWindow interactionSystemWindow = GetWindow(typeof(InteractionSystemWindow));

            interactionSystemWindow.titleContent = new GUIContent(nameof(InteractionSystem));
        }
    }
}
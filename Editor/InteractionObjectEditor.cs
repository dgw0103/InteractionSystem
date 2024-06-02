using UnityEditor;
using UnityEngine;
using HoJin.InteractionSystem;

namespace HoJin.InteractionSystemEditor
{
    [CustomEditor(typeof(InteractionObject), true)]
    [CanEditMultipleObjects]
    public class InteractionObjectEditor : Editor
    {
        private InteractionObject interactionObject;



        private void OnEnable()
        {
            interactionObject = target as InteractionObject;
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (interactionObject.TryGetComponent(out Collider collider) == false)
            {
                EditorGUILayout.HelpBox($"Add any collider at this {nameof(GameObject)}", MessageType.Warning);
            }
            if (interactionObject.TryGetComponent(out ITargeting targeting) == false)
            {
                EditorGUILayout.HelpBox($"Add Targeting component at this {nameof(GameObject)}", MessageType.Warning);
            }
        }
    }
}
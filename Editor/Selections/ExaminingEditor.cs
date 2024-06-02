using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using HoJin.InteractionSystem;

namespace HoJin.InteractionSystemEditor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(ExaminingEditor))]
    public class ExaminingEditor : Editor
    {
        private Examining examining;



        private void OnEnable()
        {
            examining = target as Examining;
        }
        public override void OnInspectorGUI()
        {
            if (examining.TryGetComponent(out CameraMoving cameraMoving))
            {

            }
            base.OnInspectorGUI();
        }
    }
}
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using System.Collections.Generic;

namespace PlayableDesign.Editor
{

    [CustomEditor(typeof(RuntimeExample))]
    public class EditorExample : UnityEditor.Editor
    {
        SerializedProperty exampleField;

        public void OnEnable()
        {
            exampleField = serializedObject.FindProperty("exampleField");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(exampleField, true);
            serializedObject.ApplyModifiedProperties();
        }
    }
}

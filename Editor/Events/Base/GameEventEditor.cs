using System;
using PlayableDesign.Events;
using UnityEditor;
using UnityEngine;

namespace PlayableDesign.Events.Editors
{
    public class GameEventEditor<T> : UnityEditor.Editor
    {

        private GameEvent<T> e;

        private GUIStyle HEADER;
        private bool showFoldout;

        private void Awake()
        {
            HEADER = new GUIStyle(EditorStyles.foldoutHeader);
        }

        private void OnEnable()
        {
            if (e == null)
            {
                e = (GameEvent<T>)target;
            }
        }

        public override void OnInspectorGUI()
        {
            base.DrawDefaultInspector();

            GUILayout.Space(20f);

            showFoldout = EditorGUILayout.Foldout(showFoldout, "Subscribers", HEADER);
            if (showFoldout)
            {
                if (Application.isPlaying)
                {
                    foreach (var s in e.Subscribers)
                    {
                        GUILayout.Label("Subscriber: " + s);
                    }
                }
            }

            GUILayout.Space(10f);

            if (GUILayout.Button("Publish", GUILayout.ExpandWidth(true)))
            {
                if (Application.isPlaying)
                {
                    var go = new GameObject(e.name);
                    e.Publish(go, e.testValue);
                    Destroy(go);
                }
            }

        }

    }
}

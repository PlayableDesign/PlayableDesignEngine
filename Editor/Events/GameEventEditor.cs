
using PlayableDesign.Events;
using UnityEditor;
using UnityEngine;

namespace PlayableDesign
{
    // [CustomEditor(typeof(GameEvent<>), true)]
    public class GameEventEditor<T> : Editor
    {
        private GameEvent<T> e;
        //public T arg;

        private void OnEnable()
        {
            if (e == null)
            {
                e = (GameEvent<T>)target;
            }
        }

        public override void OnInspectorGUI()
        {

            if (GUILayout.Button("Publish", GUILayout.ExpandWidth(true)))
            {
                e.Publish(new GameObject("Test"), e.testValue);
            }

            base.DrawDefaultInspector();

        }




    }
}

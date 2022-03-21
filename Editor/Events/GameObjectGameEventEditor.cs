
using PlayableDesign.Events;
using UnityEditor;
using UnityEngine;

namespace PlayableDesign
{
    [CustomEditor(typeof(GameObjectGameEvent))]
    public class GameObjectGameEventEditor : GameEventEditor<GameObject> { }
}

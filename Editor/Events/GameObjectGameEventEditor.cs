
using PlayableDesign.Events;
using UnityEditor;
using UnityEngine;

namespace PlayableDesign.Events.Editors
{
    [CustomEditor(typeof(GameObjectGameEvent))]
    public class GameObjectGameEventEditor : GameEventEditor<GameObject> { }
}

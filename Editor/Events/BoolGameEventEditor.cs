
using PlayableDesign.Events;
using UnityEditor;

namespace PlayableDesign
{
    [CustomEditor(typeof(BoolGameEvent))]
    public class BoolGameEventEditor : GameEventEditor<bool> { }
}

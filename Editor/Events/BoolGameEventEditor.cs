
using PlayableDesign.Events;
using UnityEditor;

namespace PlayableDesign.Events.Editors
{
    [CustomEditor(typeof(BoolGameEvent))]
    public class BoolGameEventEditor : GameEventEditor<bool> { }
}

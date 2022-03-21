
using PlayableDesign.Events;
using UnityEditor;

namespace PlayableDesign.Events.Editors
{
    [CustomEditor(typeof(IntGameEvent))]
    public class IntGameEventEditor : GameEventEditor<int> { }
}

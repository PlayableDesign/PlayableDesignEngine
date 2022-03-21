
using PlayableDesign.Events;
using UnityEditor;

namespace PlayableDesign.Events.Editors
{
    [CustomEditor(typeof(EmptyGameEvent))]
    public class EmptyGameEventEditor : GameEventEditor<EmptyArg> { }
}


using PlayableDesign.Events;
using UnityEditor;

namespace PlayableDesign
{
    [CustomEditor(typeof(EmptyGameEvent))]
    public class EmptyGameEventEditor : GameEventEditor<EmptyArg> { }
}

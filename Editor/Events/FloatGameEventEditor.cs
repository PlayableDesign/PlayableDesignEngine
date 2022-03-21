
using PlayableDesign.Events;
using UnityEditor;

namespace PlayableDesign
{
    [CustomEditor(typeof(FloatGameEvent))]
    public class FloatGameEventEditor : GameEventEditor<float> { }
}

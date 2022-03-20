
using UnityEngine;

namespace PlayableDesign.Events
{
    [CreateAssetMenu(fileName = "GameEventSO", menuName = "Events/EmptyGameEventSO")]
    public class EmptyGameEvent : GameEvent<EmptyArg> { }
}
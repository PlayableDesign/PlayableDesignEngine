
using UnityEngine;

namespace PlayableDesign.Events
{
    public class TimerArg
    {
        public TimerArg(float time, float elapsed, float remaining)
        {
            Time = time;
            Elapsed = elapsed;
            Remaining = remaining;
        }

        public float Time;
        public float Elapsed;
        public float Remaining;
    }
}

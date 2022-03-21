
using System.Collections;
using PlayableDesign.Events;
using UnityEngine;

namespace PlayableDesign
{
    public class CountDownComponent : ExtendedBehavior
    {
        #region INSPECTOR

        [Header("Scriptable Objects")]
        [SerializeField] private TimerGameEvent tickEventSO;
        [SerializeField] private EmptyGameEvent completeEventSO;

        [Header("References")]
        [SerializeField] private float time;
        [SerializeField] private float tick;
        [SerializeField] private bool countOnStart;

        #endregion

        #region PRIVATE STATE 
        private float _timeRemaining;
        private float _timeElapsed;
        #endregion

        #region PRIVATE CACHE 
        private WaitForSeconds _tick;
        #endregion

        #region LIFECYCLE

        private void Awake()
        {
            AssertSO<EmptyGameEvent>(completeEventSO);
            AssertSO<TimerGameEvent>(tickEventSO);
            Debug.AssertFormat(time > 0f && time > tick,
             "Invalid CountDownBehavior Settings: Seconds: {0], Tick: {1}",
              time, tick);

            LogInfo("Initialized");
        }

        private void Start()
        {
            if (countOnStart)
            {
                LogInfo("Starting countdown...");
                StartCoroutine(CountDown());
            }
        }

        #endregion

        #region METHODS

        private IEnumerator CountDown()
        {
            while (_timeRemaining > 0)
            {
                yield return _tick;
                _timeElapsed += tick;
                _timeRemaining -= tick;
                tickEventSO.Publish(gameObject, new TimerArg(time, _timeElapsed, _timeRemaining));
            }

            completeEventSO.Publish(gameObject, EmptyArg.EMPTY);
        }

        #endregion

    }
}
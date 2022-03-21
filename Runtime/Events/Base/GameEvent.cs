
using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlayableDesign.Events
{
    public abstract class GameEvent<T> : ScriptableObject
    {

        #region CONSTANTS
        private const string LOG_DELEGATES = "<color=#{0}><b>{1} {2}</b> callback on <b>{3} {4} {5}</b></color>";
        private const string LOG = "<color=#{0}><b>{1} {2}</b> published by <b>{3}</b></color>";
        #endregion

        #region INSPECTOR

        [Header("Logging")]

        [SerializeField]
        [Tooltip("Enable logging in the Editor")]
        private bool enableLog;

        [SerializeField]
        [Tooltip("Set the color for log messages")]
        private Color logColor = Color.white;

        [Tooltip("Set a test value to use for publishing from the Inspector")]
        public T testValue;

        #endregion

        #region PUBLIC

        public event Action<GameObject, T> Callback;
        public Func<bool> CallbackFilter;

        public string[] Subscribers
        {
            get
            {
                var results = new List<string>();

                Delegate[] delegates = Callback?.GetInvocationList();

                if (delegates != null)
                {

                    foreach (Delegate d in delegates)
                    {
                        if (d != null)
                        {
                            var target = d.Target.ToString().Split();
                            var go = target[0];
                            results.Add(go);
                        }
                    }
                }

                return results.ToArray();
            }
        }

        #endregion

        #region PROTECTED STATE 

        protected string _htmlColor => ColorUtility.ToHtmlStringRGB(logColor);

        #endregion

        #region METHODS

        public void Publish(GameObject sender, T arg)
        {
            try
            {
                Callback?.Invoke(sender, arg);
                Log(sender, arg);
            }
            catch (Exception ex)
            {
                Debug.LogErrorFormat(this, ex.ToString());
            }
        }

        private void Log(GameObject sender, T arg)
        {
            if (enableLog)
            {
                Debug.LogFormat(this, LOG, _htmlColor, name, arg, sender.name);

                Delegate[] delegates = Callback?.GetInvocationList();

                if (delegates != null)
                {
                    foreach (Delegate d in delegates)
                    {
                        if (d != null)
                        {
                            var target = d.Target.ToString().Split();
                            var go = target[0];
                            var className = target[1].TrimStart('(').TrimEnd(')');

                            Debug.LogFormat(this, LOG_DELEGATES, _htmlColor, name, arg, go, className, d.Method.Name);
                        }
                        else
                        {
                            Debug.LogErrorFormat(this, "Null Delegate");
                        }
                    }
                }
            }
        }

        #endregion

    }

}

using System;
using UnityEngine;

namespace PlayableDesign.Events
{
    public abstract class GameEvent<T> : ScriptableObject
    {

        #region CONSTANTS
        private const string LOG_DELEGATES = "<color=#{0}>     SUBSCRIBER INVOKED: {1}, GAMEOBJECT: {2}, SCRIPT: {3}, METHOD: {4}</color>";
        private const string LOG = "<color=#{0}><b>{1}</b>: sender: {2}: arg: {3}</color>";
        #endregion

        #region INSPECTOR

        [Header("Logging")]

        [SerializeField]
        [Tooltip("Enable logging in the Editor")]
        private bool enableLog;

        [SerializeField]
        [Tooltip("Set the color for log messages")]
        private Color logColor = Color.white;


        public T testValue;

        #endregion

        #region PUBLIC

        public event Action<GameObject, T> Listener;

        #endregion

        #region PROTECTED STATE 

        protected string _htmlColor => ColorUtility.ToHtmlStringRGB(logColor);

        #endregion

        #region METHODS

        public void Publish(GameObject sender, T arg)
        {
            try
            {
                Listener?.Invoke(sender, arg);
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
                Debug.LogFormat(this, LOG, _htmlColor, name, sender.name, arg.ToString());
                LogDelegates();
            }
        }

        protected void LogDelegates()
        {
            Delegate[] delegates = Listener?.GetInvocationList();

            if (delegates != null)
            {
                foreach (Delegate d in delegates)
                {
                    if (d != null)
                    {
                        var target = d.Target.ToString().Split();
                        var go = target[0];
                        var className = target[1].TrimStart('(').TrimEnd(')');

                        Debug.LogFormat(this, LOG_DELEGATES, _htmlColor, name, go, className, d.Method.Name);
                    }
                    else
                    {
                        Debug.LogErrorFormat(this, "Null Delegate");
                    }
                }
            }
        }

        #endregion

    }

    public abstract class GameEvent<T, U> : GameEvent<T>
    {

    }

}
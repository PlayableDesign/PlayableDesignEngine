
using UnityEngine;

namespace PlayableDesign
{
    public class ExtendedBehavior : MonoBehaviour
    {

        // ------------------------------------------------------------------------------------------------------------------------
        #region CONSTANTS

        private const string DEBUG_LOG = "<color=#{0}><b>{1}</b>: {2}</color>";
        private const string DEBUG_ASSERT = "<color=#{0}><b>{1}</b>: {2} is missing or not set</color>";

        #endregion

        // ------------------------------------------------------------------------------------------------------------------------
        #region INSPECTOR

        [Header("Logging")]

        [SerializeField]
        [Tooltip("Enable logging in the Editor")]
        private bool enableLog = true;


        [SerializeField]
        [Tooltip("Set the color for log messages")]
        private Color logColor = Color.white;

        #endregion

        // ------------------------------------------------------------------------------------------------------------------------
        #region PRIVATE STATE

        public string _htmlColor;

        #endregion

        // ------------------------------------------------------------------------------------------------------------------------
        #region LIFECYCLE

        private void Awake()
        {
            if (enableLog) _htmlColor = ColorUtility.ToHtmlStringRGB(logColor);
        }

        #endregion

        // ------------------------------------------------------------------------------------------------------------------------
        #region METHODS

        protected void LogInfo(string message)
        {
            if (enableLog) Debug.LogFormat(gameObject, DEBUG_LOG, _htmlColor, name, message);
        }

        public void LogWarning(string message)
        {
            if (enableLog) Debug.LogWarningFormat(gameObject, DEBUG_LOG, _htmlColor, name, message);
        }

        public void LogError(string message)
        {
            if (enableLog) Debug.LogErrorFormat(gameObject, DEBUG_LOG, _htmlColor, name, message);
        }

        public void AssertComponent<T>(T component) where T : Component
        {
#if UNITY_EDITOR
            Debug.AssertFormat(component != null, DEBUG_ASSERT, _htmlColor, name, component.name);
            Debug.Break();
#endif
        }

        public void AssertSO<T>(T so) where T : ScriptableObject
        {
#if UNITY_EDITOR
            Debug.AssertFormat(so != null, DEBUG_ASSERT, _htmlColor, name, so.name);
            Debug.Break();
#endif
        }

        public void AssertGameObject(GameObject go)
        {
#if UNITY_EDITOR
            Debug.AssertFormat(go != null, DEBUG_ASSERT, _htmlColor, name, go.name);
            Debug.Break();
#endif
        }


        #endregion

    }
}

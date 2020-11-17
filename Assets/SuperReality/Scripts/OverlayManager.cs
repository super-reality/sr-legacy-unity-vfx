using UnityEngine;
using UnityEngine.Events;

namespace SuperReality.Scripts
{
    public class OverlayManager : MonoBehaviour
    {
        #region Fields

        [SerializeField]
        private UnityEvent onStart;

        [SerializeField]
        private UnityEvent onStop;

        private bool m_isPlaying;

        #endregion

        #region Methods

        public void StartOverlay()
        {
            if (m_isPlaying) return;
            m_isPlaying = true;
            onStart.Invoke();
        }

        public void StopOverlay()
        {
            if (!m_isPlaying) return;
            m_isPlaying = false;
            onStop.Invoke();
        }

        #endregion
    }
}

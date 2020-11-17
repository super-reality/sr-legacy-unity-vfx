using UnityEngine;
using UnityEngine.Events;

namespace SuperReality.Scripts
{
    public class EffectManager : MonoBehaviour
    {
        #region Fields

        [SerializeField]
        private UnityEvent onStart;

        [SerializeField]
        private UnityEvent onStop;

        private bool _isPlaying;

        #endregion

        #region Methods

        public void StartEffect()
        {
            if (_isPlaying) return;
            _isPlaying = true;
            onStart.Invoke();
        }

        public void StopEffect()
        {
            if (!_isPlaying) return;
            _isPlaying = false;
            onStop.Invoke();
        }

        #endregion
    }
}

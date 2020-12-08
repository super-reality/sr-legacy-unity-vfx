using UnityEngine;

namespace SuperReality.Overlays
{
    public class ParameterRelay<TValue> : MonoBehaviour
    {
        [SerializeField]
        private string parameterName;

        public string ParameterName => parameterName;

        public virtual void SetParameter(TValue value)
        {
        }
    }
}

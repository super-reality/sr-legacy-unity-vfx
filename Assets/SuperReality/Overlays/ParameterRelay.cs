using System;
using UnityEngine;
using UnityEngine.Events;

namespace SuperReality.Overlays
{
    public class ParameterRelay<TValue> : MonoBehaviour
    {
        [SerializeField]
        private string parameterName;

        [SerializeField]
        private ParameterEvent onParameterSet;

        public string ParameterName => parameterName;

        public void SetParameter(TValue value)
        {
            onParameterSet.Invoke(value);
        }

        [Serializable]
        public class ParameterEvent : UnityEvent<TValue>
        {
        }
    }
}

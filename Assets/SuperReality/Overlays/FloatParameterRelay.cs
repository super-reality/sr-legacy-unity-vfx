using System;
using UnityEngine;
using UnityEngine.Events;

namespace SuperReality.Overlays
{
    public class FloatParameterRelay : ParameterRelay<float>
    {
        [SerializeField]
        private ParameterEvent onParameterSet;

        public override void SetParameter(float value)
        {
            onParameterSet.Invoke(value);
        }

        [Serializable]
        public class ParameterEvent : UnityEvent<float>
        {
        }
    }
}

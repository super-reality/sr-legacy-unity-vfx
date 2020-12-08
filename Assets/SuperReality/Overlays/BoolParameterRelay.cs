using System;
using UnityEngine;
using UnityEngine.Events;

namespace SuperReality.Overlays
{
    public class BoolParameterRelay : ParameterRelay<bool>
    {
        [SerializeField]
        private ParameterEvent onParameterSet;

        public override void SetParameter(bool value)
        {
            onParameterSet.Invoke(value);
        }

        [Serializable]
        public class ParameterEvent : UnityEvent<bool>
        {
        }
    }
}

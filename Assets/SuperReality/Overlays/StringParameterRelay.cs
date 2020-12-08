using System;
using UnityEngine;
using UnityEngine.Events;

namespace SuperReality.Overlays
{
    public class StringParameterRelay : ParameterRelay<string>
    {
        [SerializeField]
        private ParameterEvent onParameterSet;

        public override void SetParameter(string value)
        {
            onParameterSet.Invoke(value);
        }

        [Serializable]
        public class ParameterEvent : UnityEvent<string>
        {
        }
    }
}

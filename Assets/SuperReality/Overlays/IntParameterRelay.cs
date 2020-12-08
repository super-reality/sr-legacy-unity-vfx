using System;
using UnityEngine;
using UnityEngine.Events;

namespace SuperReality.Overlays
{
    public class IntParameterRelay : ParameterRelay<int>
    {
        [SerializeField]
        private ParameterEvent onParameterSet;

        public override void SetParameter(int value)
        {
            onParameterSet.Invoke(value);
        }

        [Serializable]
        public class ParameterEvent : UnityEvent<int>
        {
        }
    }
}

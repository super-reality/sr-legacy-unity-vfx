using System;
using UnityEngine;
using UnityEngine.Events;

namespace SuperReality.Overlays
{
    public class ColorParameterRelay : ParameterRelay<Color>
    {
        [SerializeField]
        private ParameterEvent onParameterSet;

        public override void SetParameter(Color value)
        {
            onParameterSet.Invoke(value);
        }

        [Serializable]
        public class ParameterEvent : UnityEvent<Color>
        {
        }
    }
}

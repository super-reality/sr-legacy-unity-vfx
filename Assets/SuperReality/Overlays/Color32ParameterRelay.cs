using System;
using UnityEngine;
using UnityEngine.Events;

namespace SuperReality.Overlays
{
    public class Color32ParameterRelay : ParameterRelay<Color32>
    {
        [SerializeField]
        private ParameterEvent onParameterSet;

        public override void SetParameter(Color32 value)
        {
            onParameterSet.Invoke(value);
        }

        [Serializable]
        public class ParameterEvent : UnityEvent<Color32>
        {
        }
    }
}

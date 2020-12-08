using System;
using UnityEngine;
using UnityEngine.Events;

namespace SuperReality.Overlays
{
    public class Vector2ParameterRelay : ParameterRelay<Vector2>
    {
        [SerializeField]
        private ParameterEvent onParameterSet;

        public override void SetParameter(Vector2 value)
        {
            onParameterSet.Invoke(value);
        }

        [Serializable]
        public class ParameterEvent : UnityEvent<Vector2>
        {
        }
    }
}

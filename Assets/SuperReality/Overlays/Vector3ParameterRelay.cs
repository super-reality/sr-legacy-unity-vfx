using System;
using UnityEngine;
using UnityEngine.Events;

namespace SuperReality.Overlays
{
    public class Vector3ParameterRelay : ParameterRelay<Vector3>
    {
        [SerializeField]
        private ParameterEvent onParameterSet;

        public override void SetParameter(Vector3 value)
        {
            onParameterSet.Invoke(value);
        }

        [Serializable]
        public class ParameterEvent : UnityEvent<Vector3>
        {
        }
    }
}

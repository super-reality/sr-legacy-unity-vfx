using System;

namespace SuperReality.Overlays
{
    [Serializable]
    public class Parameter<TValue>
    {
        public string name;
        public TValue value;
    }
}

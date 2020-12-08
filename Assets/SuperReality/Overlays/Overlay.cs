using System;

namespace SuperReality.Overlays
{
    [Serializable]
    public class Overlay
    {
        public string id;
        public string name;
        public string[] tags;
        public Parameter[] parameters;
        public Action[] actions;

        [Serializable]
        public class Action
        {
            public string name;
        }

        [Serializable]
        public class Parameter
        {
            public string name;
            public string type;
        }
    }
}

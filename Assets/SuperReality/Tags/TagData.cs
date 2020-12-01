using UnityEngine;

namespace SuperReality.Tags
{
    [CreateAssetMenu(fileName = "New Tag", menuName = "Super Reality/Tag Data", order = -1000)]
    public class TagData : ScriptableObject
    {
        public string displayName;
    }
}

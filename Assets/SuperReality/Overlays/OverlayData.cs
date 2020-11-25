using System.Collections.Generic;
using UnityEngine;

namespace SuperReality.Scripts
{
    [CreateAssetMenu(fileName = "New Overlay Data", menuName = "Super Reality/Overlay Data", order = -1000)]
    public class OverlayData : ScriptableObject
    {
        public string displayName;

        public string buildName;

        public List<TagData> tags;

        public List<SceneReference> scenes;

        public string GetJson()
        {
            var overlay = new Overlay
            {
                displayName = displayName,
                tags = new string[tags.Count]
            };

            var sortedTags = new List<TagData>(tags);
            sortedTags.Sort((a, b) => string.CompareOrdinal(a.displayName, b.displayName));

            for (var i = 0; i < sortedTags.Count; i++)
            {
                overlay.tags[i] = sortedTags[i].displayName;
            }

            return JsonUtility.ToJson(overlay);
        }
    }
}

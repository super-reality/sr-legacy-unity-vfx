using System;
using System.Collections.Generic;
using SuperReality.Tags;
using UnityEditor;
using UnityEngine;

namespace SuperReality.Overlays
{
    [CreateAssetMenu(fileName = "New Overlay Data", menuName = "Super Reality/Overlay Data", order = -1000)]
    public class OverlayData : ScriptableObject
    {
        public string displayName;

        public string buildName;

        public List<TagData> tags;

        public List<SceneReference> scenes;

        public List<Parameter> parameters;

        public List<Action> actions = new List<Action>(new[] { new Action { name = "Start" }, new Action { name = "Stop" } });

        public string GetJson()
        {
            var overlay = new Overlay
            {
                id = new Guid(AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(this))).ToString(),
                name = displayName,
                tags = new string[tags.Count],
                parameters = new Overlay.Parameter[parameters.Count],
                actions = new Overlay.Action[actions.Count]
            };

            var sortedTags = new List<TagData>(tags);
            sortedTags.Sort((a, b) => string.CompareOrdinal(a.displayName, b.displayName));

            for (var i = 0; i < sortedTags.Count; i++)
            {
                overlay.tags[i] = sortedTags[i].displayName;
            }

            for (var i = 0; i < parameters.Count; i++)
            {
                overlay.parameters[i] = new Overlay.Parameter
                {
                    name = parameters[i].name,
                    type = parameters[i].type.ToString()
                };
            }

            for (var i = 0; i < actions.Count; i++)
            {
                overlay.actions[i] = new Overlay.Action
                {
                    name = actions[i].name
                };
            }

            return JsonUtility.ToJson(overlay);
        }

        [Serializable]
        public class Action
        {
            public string name;
        }

        [Serializable]
        public class Parameter
        {
            public string name;
            public ParameterType type;
        }
    }
}

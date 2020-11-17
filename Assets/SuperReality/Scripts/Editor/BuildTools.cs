using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SuperReality.Scripts.Editor
{
    public class BuildTools
    {
        [MenuItem("Super Reality/Build Selected Scenes")]
        public static void BuildSelectedScenes()
        {
            var selection = Selection.objects;
            var scenes = new List<Scene>();

            foreach(var item in selection)
            {
                if (item is SceneAsset)
                {
                    var sceneAsset = item as SceneAsset;
                    var scene = SceneManager.GetSceneByName(sceneAsset.name);
                    if (scene.buildIndex >= 0)
                    {
                        scenes.Add(scene);
                    }
                    else
                    {
                        Debug.LogError($"The selected scene '{sceneAsset.name}' is not in the build. Add it in the build settings, then run this again.");
                    }
                }
            }

            if (scenes.Count > 0)
            {
                Debug.Log($"Selected {scenes.Count} {(scenes.Count == 1 ? "scene" : "scenes")} to build");

                for (var i = 0; i < scenes.Count; i++)
                {
                    var scene = scenes[i];

                    var buildPlayerOptions = new BuildPlayerOptions
                    {
                        scenes = new[] { scene.path },
                        locationPathName = "Builds/" + scene.name,
                        target = BuildTarget.WebGL,
                        options = BuildOptions.None
                    };

                    Debug.Log($"Building scene '{scene.name}' ({i + 1}/{scenes.Count})...");

                    var report = BuildPipeline.BuildPlayer(buildPlayerOptions);
                    var summary = report.summary;

                    if (summary.result == BuildResult.Succeeded)
                    {
                        Debug.Log($"Built scene '{scene.name}' successfully");
                    }

                    if (summary.result == BuildResult.Failed)
                    {
                        Debug.LogError($"Failed to build scene '{scene.name}'");
                    }

                    if (summary.result == BuildResult.Cancelled)
                    {
                        Debug.LogWarning("Cancelled building scene '{scene.name}'");
                        break;
                    }
                }
            }
            else
            {
                Debug.LogWarning("No scenes to build. Check your selection.");
            }
        }
    }
}

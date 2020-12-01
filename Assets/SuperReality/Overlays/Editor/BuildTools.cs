using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace SuperReality.Overlays.Editor
{
    public static class BuildTools
    {
        [MenuItem("Super Reality/Overlays/Build Selected")]
        public static void BuildSelectedScenes()
        {
            var selection = Selection.objects;
            var overlays = new List<OverlayData>();

            foreach(var item in selection)
            {
                if (item is OverlayData overlay)
                {
                    overlays.Add(overlay);
                }
            }

            if (overlays.Count > 0)
            {
                Debug.Log($"Selected {overlays.Count} {(overlays.Count == 1 ? "overlay" : "overlays")} to build");
                foreach (var overlay in overlays)
                {
                    if (!BuildOverlay(overlay))
                    {
                        break;
                    }
                }
            }
            else
            {
                Debug.LogWarning("No overlays to build");
            }
        }

        private static bool BuildOverlay(OverlayData overlay)
        {
            Debug.Log($"Building overlay '{overlay.displayName}'");

            var buildPath = Path.Combine("Builds", overlay.buildName);

            var buildPlayerOptions = new BuildPlayerOptions
            {
                scenes = new string[overlay.scenes.Count],
                locationPathName = buildPath,
                target = BuildTarget.WebGL,
                options = BuildOptions.None
            };

            for (var i = 0; i < overlay.scenes.Count; i++)
            {
                buildPlayerOptions.scenes[i] = overlay.scenes[i].ScenePath;
            }

            var report = BuildPipeline.BuildPlayer(buildPlayerOptions);
            var summary = report.summary;
            var success = false;

            if (summary.result == BuildResult.Succeeded)
            {
                Debug.Log($"Successfully built overlay '{overlay.displayName}'");

                using (var streamWriter = File.CreateText(Path.Combine(buildPath, "data.json")))
                {
                    streamWriter.Write(overlay.GetJson());
                }

                success = true;
            }

            if (summary.result == BuildResult.Failed)
            {
                Debug.LogError($"Failed to build overlay '{overlay.displayName}'");
            }

            if (summary.result == BuildResult.Cancelled)
            {
                Debug.LogWarning($"Cancelled building overlay '{overlay.displayName}'");
            }

            return success;
        }
    }
}

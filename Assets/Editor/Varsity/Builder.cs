using System.IO;
using System.Diagnostics;

using UnityEditor;

namespace Varsity
{
    public static class Builder {
        public static bool Build() {
            return PreBuild()
                && RunBuild()
                && PostBuild();

        }

        private static bool PreBuild() {
            return true;
        }

        private static bool RunBuild() {
            var buildOptions = MakeBuildOptions();
            BuildPipeline.BuildPlayer(buildOptions);
            return true;
        }

        private static bool PostBuild() {
            FileUtil.CopyFileOrDirectory("Readme.md", Path.Combine(MakeBuildPath(), "Readme.md"));
            return true;
        }

        private static BuildPlayerOptions MakeBuildOptions() {
            var path = MakeBuildPath();
            var scenes = new string[] { "Assets/Scenes/SampleScene.unity" };
            var locationPathName = path;

            return new BuildPlayerOptions {
                scenes = scenes,
                target = BuildTarget.iOS,
                options = UnityEditor.BuildOptions.None,
                locationPathName = locationPathName,
            };
        }
    
        private static string MakeBuildPath() {
            return "Builds/Build-2022-10-001";
	    }

        private static int RunApplication(string path) {
            var proc = new Process();
            proc.StartInfo.FileName = path;
            proc.Start();
            return 0;
        }
    }
}


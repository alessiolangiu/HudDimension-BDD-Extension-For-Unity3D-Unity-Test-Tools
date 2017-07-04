using UnityEditor;
using UnityEngine;

namespace HudDimension.BDDExtensionForUnityTestTools
{
    public static class Utilities
    {
        public static string GetAssetFullPath(BDDExtensionRunner bddExtensionRunner, string fileName)
        {
            string result = string.Empty;
            if (bddExtensionRunner != null)
            {
                MonoScript script= MonoScript.FromMonoBehaviour(bddExtensionRunner);
                string runnerFullPath = AssetDatabase.GetAssetPath(script);
                string runnerPath = runnerFullPath.Substring(0, runnerFullPath.Length - "BDDExtensionRunner.cs".Length-1);
                result = runnerPath + System.IO.Path.DirectorySeparatorChar + "Resources" + System.IO.Path.DirectorySeparatorChar + "Sprites" + System.IO.Path.DirectorySeparatorChar + fileName;
            }
            return result;
        }
    }
}

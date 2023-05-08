using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

namespace LunarflyArts
{
    public class ManageSceneOnTheFly
    {
        [MenuItem("Tools/Add-ons/Play First Scene")]
        public static void PlayFirstSceneAndReturn()
        {
            // Save the path of the current active scene so that we can return to it later
            string currentScenePath = SceneManager.GetActiveScene().path;

            // Load the first scene in the build index
            SceneAsset firstScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(SceneUtility.GetScenePathByBuildIndex(0));
            EditorSceneManager.OpenScene(AssetDatabase.GetAssetPath(firstScene), OpenSceneMode.Single);
            EditorApplication.isPlaying = true;

            // Restore the previously active scene when exiting play mode
            EditorApplication.playModeStateChanged += (PlayModeStateChange state) =>
            {
                if (state == PlayModeStateChange.ExitingPlayMode)
                {
                    EditorSceneManager.OpenScene(currentScenePath, OpenSceneMode.Single);
                }
            };
        }
    }
}

using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

namespace LunarflyArts
{
    public class ManageSceneOnTheFly
    {
        [MenuItem("Tools/Add-ons/Play First Scene %#&p")]
        public static void PlayFirstSceneAndReturn()
        {
            // Save the current scene so that we can return to it later
            Scene currentScene = SceneManager.GetActiveScene();

            // Save the scene to a temporary path if it has not been saved before
            if (string.IsNullOrEmpty(currentScene.path))
            {
                EditorSceneManager.SaveScene(currentScene, "Assets/TempScene.unity");
                currentScene = EditorSceneManager.GetActiveScene();
            }
            else
            {
                EditorSceneManager.SaveScene(currentScene);
            }

            // Load and play the first scene in the build index
            SceneAsset firstScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(SceneUtility.GetScenePathByBuildIndex(0));
            EditorSceneManager.OpenScene(AssetDatabase.GetAssetPath(firstScene), OpenSceneMode.Single);
            EditorApplication.isPlaying = true;

            // Return to the previously active scene when the game stops playing
            EditorApplication.playModeStateChanged += (PlayModeStateChange state) =>
            {
                if (state == PlayModeStateChange.ExitingPlayMode)
                {
                    EditorSceneManager.OpenScene(currentScene.path, OpenSceneMode.Single);
                }
            };
        }
    }
}

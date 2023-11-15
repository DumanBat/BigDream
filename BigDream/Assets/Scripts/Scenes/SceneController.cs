using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BigDream.App
{
    public class SceneController : MonoBehaviour
    {
        public void Init(string[] sceneNames)
        {
            foreach (var sceneName in sceneNames)
                CheckIfSceneExists(sceneName);
        }

        public bool LoadScene(string name, ISceneLoadRequest sender)
        {
            var isSceneExists = CheckIfSceneExists(name);

            if (!isSceneExists)
                return false;

            StartCoroutine(LoadSceneRoutine(name, sender));
            return true;
        }

        private IEnumerator LoadSceneRoutine(string name, ISceneLoadRequest sender)
        {
            var op = SceneManager.LoadSceneAsync(name);
            yield return new WaitUntil(() => op.isDone);

            sender.OnSceneLoaded?.Invoke();
        }

        private bool CheckIfSceneExists(string name)
        {
            int buildIndex = SceneUtility.GetBuildIndexByScenePath(name);

            if (buildIndex == -1)
            {
                Debug.LogWarning($"Scene {name} is not exists or not included in the build");
                return false;
            }

            return true;
        }
    }
}

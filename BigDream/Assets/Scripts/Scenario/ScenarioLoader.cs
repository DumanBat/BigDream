using BigDream.App;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigDream.Scenarios
{
    public class ScenarioLoader : MonoBehaviour, ISceneLoadRequest
    {
        private ScenarioConfig _currentScenario;

        public Action OnSceneLoaded { get; set; }

        public void LoadScenario(ScenarioConfig config)
        {
            _currentScenario = config;
            OnSceneLoaded += LoadScenarioData;
            LoadScene(config.SceneName);
        }

        public void LoadScene(string sceneName)
        {
            var isExists = ApplicationController.Instance.SceneController.LoadScene(sceneName, this);

            if (!isExists)
            {
                _currentScenario = null;
                OnSceneLoaded -= LoadScenarioData;
            }
        }

        private void LoadScenarioData()
        {
            var scenarioSceneMediator = Instantiate(_currentScenario.ScenarioSceneMediatorPrefab);
            scenarioSceneMediator.Init(_currentScenario);
        }
    }
}

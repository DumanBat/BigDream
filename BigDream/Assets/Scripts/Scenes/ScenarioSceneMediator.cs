using BigDream.App;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigDream.Scenarios
{
    public class ScenarioSceneMediator : MonoBehaviour, ISceneLoadRequest
    {
        private const string MainMenu = "MenuScene";

        [SerializeField]
        private ScenarioSelectionController _scenarioSelectionControllerPrefab;
        [SerializeField]
        private ScenarioDataController _scenarioDataControllerPrefab;
        [SerializeField]
        private ScenarioMenu _scenarioMenuPrefab;

        private ScenarioSelectionController _scenarioSelectionController;
        private ScenarioDataController _scenarioDataController;
        private ScenarioMenu _scenarioMenu;

        public Action OnSceneLoaded { get; set; }

        public void Init(ScenarioConfig config)
        {
            _scenarioSelectionController = Instantiate(_scenarioSelectionControllerPrefab);
            _scenarioMenu = Instantiate(_scenarioMenuPrefab);
            _scenarioDataController = Instantiate(_scenarioDataControllerPrefab);

            OnSceneLoaded += ApplicationController.Instance.Init;

            _scenarioSelectionController.Init(ApplicationController.Instance.ProjectConfiguration.Scenarios);
            _scenarioDataController.Init(config);

            _scenarioSelectionController.CloseButtonClicked += () =>
            {
                _scenarioSelectionController.SetActivePanel(false);
                _scenarioMenu.SetActivePanel(true);
                _scenarioDataController.SetActivePanel(true);
            };
            _scenarioMenu.BackToMenuButtonClicked += () =>
            {
                LoadScene(MainMenu);
            };
            _scenarioMenu.ScenarioSelectionButtonClicked += () =>
            {
                _scenarioSelectionController.SetActivePanel(true);
                _scenarioMenu.SetActivePanel(false);
                _scenarioDataController.SetActivePanel(false);
            };

            LoadEnvironment(config);
        }

        private void LoadEnvironment(ScenarioConfig config)
        {
            var scenarioEnvironment = Instantiate(config.ScenarioPrefab);
        }

        public void LoadScene(string sceneName)
        {
            ApplicationController.Instance.SceneController.LoadScene(sceneName, this);
        }
    }
}

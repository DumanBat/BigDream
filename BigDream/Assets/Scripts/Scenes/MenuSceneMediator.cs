using BigDream.Data;
using BigDream.Scenarios;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigDream.Menu
{
    public class MenuSceneMediator : MonoBehaviour
    {
        [SerializeField]
        private MenuController _menuControllerPrefab;
        [SerializeField]
        private ScenarioSelectionController _scenarioSelectionControllerPrefab;

        private MenuController _menuController;
        private ScenarioSelectionController _scenarioSelectionController;

        private void Awake()
        {
            _menuController = Instantiate(_menuControllerPrefab);
            _scenarioSelectionController = Instantiate(_scenarioSelectionControllerPrefab);

            _menuController.ScenarioSelectionButtonClicked += () => _scenarioSelectionController.SetActivePanel(true);
            _scenarioSelectionController.CloseButtonClicked += () => _menuController.SetActivePanel(true);

            _menuController.SetActivePanel(true);
            _scenarioSelectionController.SetActivePanel(false);
        }

        public void Init(ScenarioConfig[] configs)
        {
            _scenarioSelectionController.Init(configs);
        }
    }
}

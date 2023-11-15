using BigDream.Scenarios;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigDream.Menu
{
    public class MenuSceneMediator : MonoBehaviour
    {
        [SerializeField]
        private MenuController _menuController;
        [SerializeField]
        private ScenarioSelectionController _scenarioSelectionController;

        private void Awake()
        {
            _menuController.ScenarioSelectionButtonClicked += () => _scenarioSelectionController.SetActivePanel(true);
            _scenarioSelectionController.CloseButtonClicked += () => _menuController.SetActivePanel(true);
        }

        private void Start()
        {
            _menuController.SetActivePanel(true);
            _scenarioSelectionController.SetActivePanel(false);
        }

        public void Init(ScenarioConfig[] scenarios)
        {
            _scenarioSelectionController.Init(scenarios);
        }
    }
}

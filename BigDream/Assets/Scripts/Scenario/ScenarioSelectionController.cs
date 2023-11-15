using BigDream.Menu;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BigDream.Scenarios
{
    public class ScenarioSelectionController : MonoBehaviour
    {
        [SerializeField]
        private ScenarioLoader _scenarioLoader;

        [Space]
        [SerializeField]
        private Transform _canvas;
        [SerializeField]
        private Button _closePanelButton;
        [SerializeField]
        private Button _startScenarioButton;
        [SerializeField]
        private ToggleGroup _scenariosContainer;
        [SerializeField]
        private ScenarioListItem _scenarioListItemPrefab;

        public Action CloseButtonClicked;

        private ScenarioConfig _selectedScenario;

        private void Awake()
        {
            _closePanelButton.onClick.AddListener(() =>
            {
                SetActivePanel(false);
                CloseButtonClicked?.Invoke();
            });

            _startScenarioButton.onClick.AddListener(() =>
            {
                if (_selectedScenario == null)
                {
                    Debug.LogWarning("Scenario is not selected");
                    return;
                }
                _scenarioLoader.LoadScenario(_selectedScenario);
            });
        }

        public void Init(ScenarioConfig[] scenarios)
        {
            LoadScenarioList(scenarios);
        }

        private void LoadScenarioList(ScenarioConfig[] scenarios)
        {
            foreach (var scenario in scenarios)
            {
                var scenarioListItem = Instantiate(_scenarioListItemPrefab, _scenariosContainer.transform);

                scenarioListItem.Init(scenario.ScenarioName, scenario.SceneName, _scenariosContainer, 
                    (isOn) => SelectScenario(isOn, scenario));
            }
        }

        private void SelectScenario(bool isSelected, ScenarioConfig config)
        {
            _selectedScenario = isSelected ? config : null;
        }

        public void SetActivePanel(bool isActive) => _canvas.gameObject.SetActive(isActive);
    }
}

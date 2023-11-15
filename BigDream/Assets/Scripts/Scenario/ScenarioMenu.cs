using BigDream.App;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BigDream.Scenarios
{
    public class ScenarioMenu : MonoBehaviour
    {
        [SerializeField]
        private Transform _canvas;
        [SerializeField]
        private Button _backToMenuButton;
        [SerializeField]
        private Button _scenarioSelectionButton;

        public Action BackToMenuButtonClicked;
        public Action ScenarioSelectionButtonClicked;

        private void Awake()
        {
            _backToMenuButton.onClick.AddListener(() => BackToMenuButtonClicked?.Invoke());
            _scenarioSelectionButton.onClick.AddListener(() => ScenarioSelectionButtonClicked?.Invoke());
        }

        public void SetActivePanel(bool isActive) => _canvas.gameObject.SetActive(isActive);
    }
}

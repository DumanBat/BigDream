using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BigDream.Menu
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField]
        private Transform _canvas;
        [SerializeField]
        private Button _selectScenarioButton;
        [SerializeField]
        private Button _exitButton;

        public Action ScenarioSelectionButtonClicked;

        private void Awake()
        {
            _selectScenarioButton.onClick.AddListener(() =>
            {
                SetActivePanel(false);
                ScenarioSelectionButtonClicked?.Invoke();
            });

            _exitButton.onClick.AddListener(Application.Quit);
        }

        public void SetActivePanel(bool isActive) => _canvas.gameObject.SetActive(isActive);
    }
}

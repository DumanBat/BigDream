using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace BigDream.Scenarios
{
    public class ScenarioListItem : MonoBehaviour
    {
        [SerializeField]
        private Toggle _toggle;
        [SerializeField]
        private TextMeshProUGUI _scenarioName;
        [SerializeField]
        private TextMeshProUGUI _sceneName;

        private Outline _outline;

        private void Awake()
        {
            _outline = GetComponent<Outline>();
        }

        public void Init(string scenarioName, string sceneName, ToggleGroup toggleGroup, Action<bool> callback)
        {
            _scenarioName.text = scenarioName;
            _sceneName.text = sceneName;
            _toggle.group = toggleGroup;

            _toggle.onValueChanged.AddListener(delegate (bool isSelected) 
            {
                _outline.enabled = isSelected;
                callback?.Invoke(isSelected);
            });
        }
    }
}

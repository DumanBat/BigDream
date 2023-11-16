using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BigDream.Scenarios
{
    public class ScenarioDataController : MonoBehaviour
    {
        [SerializeField]
        private Transform _canvas;
        [SerializeField]
        private TextMeshProUGUI _language;
        [SerializeField]
        private TextMeshProUGUI _tableName;
        [SerializeField]
        private TextMeshProUGUI _itemsCount;
        [SerializeField]
        private Transform _scenariosDataContainer;
        [SerializeField]
        private ScenarioDataListItem _scenarioDataListItemPrefab;

        public void Init(ScenarioConfig config)
        {
            _tableName.text = config.TableName;
            _itemsCount.text = config.ScenariosJsonData.Length.ToString();

            foreach (var dataElement in config.ScenariosJsonData)
            {
                var dataElementInstance = Instantiate(_scenarioDataListItemPrefab, _scenariosDataContainer);
                dataElementInstance.Init(dataElement.dataOne, dataElement.dataTwo);
            }
        }

        public void SetActivePanel(bool isActive) => _canvas.gameObject.SetActive(isActive);
    }
}
using BigDream.Data;
using BigDream.Utils;
using UnityEngine;

namespace BigDream.Scenarios
{
    [CreateAssetMenu(fileName = "NewScenarioConfig", menuName = "Scenarios/Scenario Config")]
    public class ScenarioConfig : ScriptableObject
    {
        [Tooltip("Scenarios must be created using context menu. Scenarios -> Scenario Config.\n" +
        "Duplicating existing scenarios using Ctrl + D will duplicate ID as well.")]
        [ScriptableObjectId]
        public string scenarioId;

        [SerializeField]
        private string _scenarioName;
        [SerializeField]
        private string _sceneName;
        [SerializeField]
        private GameObject _scenarioPrefab;
        [SerializeField]
        private ScenarioJsonData[] _scenariosJsonData;

        public string ScenarioName => _scenarioName;
        public string SceneName => _sceneName;
        public GameObject ScenarioPrefab => _scenarioPrefab;
        public ScenarioJsonData[] ScenariosJsonData => _scenariosJsonData;
    }
}

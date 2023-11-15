using BigDream.Data;
using BigDream.Utils;
using UnityEngine;
using UnityEngine.AddressableAssets;

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
        private AssetReference _scenarioPrefab;
        [SerializeField]
        private ScenarioSceneMediator _scenarioSceneMediatorPrefab;
        [SerializeField]
        private ScenarioJsonData[] _scenariosJsonData;

        public string ScenarioName => _scenarioName;
        public string SceneName => _sceneName;
        public AssetReference ScenarioPrefab => _scenarioPrefab;
        public ScenarioSceneMediator ScenarioSceneMediatorPrefab => _scenarioSceneMediatorPrefab;
        public ScenarioJsonData[] ScenariosJsonData => _scenariosJsonData;
    }
}

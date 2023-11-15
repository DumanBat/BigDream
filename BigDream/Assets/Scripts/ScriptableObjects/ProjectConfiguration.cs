using BigDream.Scenarios;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigDream.Data
{
    [CreateAssetMenu(fileName = "NewProjectConfiguration", menuName = "App/Project Configuration")]
    public class ProjectConfiguration : ScriptableObject
    {
        [SerializeField]
        private ScenarioConfig[] _scenarios;

        public ScenarioConfig[] Scenarios => _scenarios;
    }
}

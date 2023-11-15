using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigDream.Scenarios
{
    public class ScenarioLoader: MonoBehaviour
    {
        public void LoadScenario(ScenarioConfig config)
        {
            Debug.Log("loading " + config.scenarioId);
        }
    }
}

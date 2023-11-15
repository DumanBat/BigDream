using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BigDream.Scenarios
{
    public class ScenarioDataListItem : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _dataOneDisplay;
        [SerializeField]
        private TextMeshProUGUI _dataTwoDisplay;

        public void Init(string dataOne, string dataTwo)
        {
            _dataOneDisplay.text = dataOne;
            _dataTwoDisplay.text = dataTwo;
        }
    }
}

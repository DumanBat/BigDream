using BigDream.Data;
using BigDream.Menu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigDream.App
{
    public class ApplicationController : MonoBehaviour
    {
        [SerializeField]
        private ProjectConfiguration _projectConfiguration;

        [SerializeField]
        private MenuSceneMediator _menuSceneMediator;

        private void Start()
        {
            _menuSceneMediator.Init(_projectConfiguration.Scenarios);
        }
    }
}

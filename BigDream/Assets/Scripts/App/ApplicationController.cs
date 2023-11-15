using BigDream.Data;
using BigDream.Menu;
using BigDream.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigDream.App
{
    public class ApplicationController : Singleton<ApplicationController>
    {
        [SerializeField]
        private ProjectConfiguration _projectConfiguration;

        [SerializeField]
        private SceneController _sceneController;
        [SerializeField]
        private MenuSceneMediator _menuSceneMediatorPrefab;

        public ProjectConfiguration ProjectConfiguration => _projectConfiguration;
        public SceneController SceneController => _sceneController;

        private MenuSceneMediator _menuSceneMediator;

        private void Start()
        {
            _sceneController.Init(_projectConfiguration.SceneNames);

            Init();
            DontDestroyOnLoad(gameObject);
        }

        public void Init()
        {
            _menuSceneMediator = Instantiate(_menuSceneMediatorPrefab);
            _menuSceneMediator.Init(_projectConfiguration.Scenarios);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigDream.App
{
    public interface ISceneLoadRequest
    {
        Action OnSceneLoaded { get; set; }
        void LoadScene(string sceneName);
    }
}

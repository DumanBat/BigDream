using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigDream.Utils
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this as T;
            }
        }
    }
}

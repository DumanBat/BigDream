using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace BigDream.Utils
{
    public static class LocalAssetProvider
    {
        public static Dictionary<AssetReference, AsyncOperationHandle<GameObject>> loadedAssets = 
            new Dictionary<AssetReference, AsyncOperationHandle<GameObject>>();

        public static AsyncOperationHandle<GameObject> GetOrLoadAssetAsync(AssetReference assetRef)
        {
            if (loadedAssets.TryGetValue(assetRef, out var handle))
                return handle;

            var loadHandle = assetRef.LoadAssetAsync<GameObject>();
            loadHandle.Completed += op => loadedAssets.Add(assetRef, op);
            return loadHandle;
        }
    }
}

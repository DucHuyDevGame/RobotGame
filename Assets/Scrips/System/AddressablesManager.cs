using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;

public class AddressablesManager : MonoBehaviour
{
    List<AsyncOperationHandle> _spriteHandles = new();
    public IEnumerator InitAddressable
    {
        get
        {
            var InitAddressablesAsync = Addressables.InitializeAsync();
            yield return InitAddressablesAsync;

            yield return LoadSpritesLocal("UIGame");
            Debug.LogError("Load sprite done");

            yield return PreloadAllLevels("Level");
            Debug.LogError("Load Level done");
        }
    }

    IEnumerator LoadSpritesLocal(string label)
    {
        var locs = Addressables.LoadResourceLocationsAsync(label, typeof(Sprite));
        yield return locs;
        if (locs.Status != AsyncOperationStatus.Succeeded || locs.Result == null || locs.Result.Count == 0)
        {
            Debug.LogWarning($"[{label}] không có Sprite nào.");
            Addressables.Release(locs);
            yield break;
        }

        foreach (var loc in locs.Result)
        {
            var h = Addressables.LoadAssetAsync<Sprite>(loc);
            _spriteHandles.Add(h);
            yield return h;
            if (h.Status == AsyncOperationStatus.Succeeded && h.Result != null)
                SpriteLibControl.AllSprites[h.Result.name] = h.Result;
            yield return null;
        }
        Addressables.Release(locs);
    }
    IEnumerator PreloadAllLevels(string label)
    {
        var locs = Addressables.LoadResourceLocationsAsync(label, typeof(SceneInstance));
        yield return locs;
        if (locs.Status != AsyncOperationStatus.Succeeded)
        {
            Debug.LogError($"Không tìm thấy scene nào với label {label}");
            yield break;
        }
        foreach (IResourceLocation loc in locs.Result)
            Debug.Log($"Preloaded deps for scene: {loc.PrimaryKey}");

        Addressables.Release(locs);
    }

}

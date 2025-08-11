using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;

public class SpriteLibControl : BYSingletonMono<SpriteLibControl>
{
    public static readonly Dictionary<string, Sprite> AllSprites = new Dictionary<string, Sprite>();
    public static async Task InitSprites(string assestLabel)
    {
        var locations = await Addressables.LoadResourceLocationsAsync(assestLabel, typeof(Sprite)).Task;
        List<Task<Sprite>> tasks = new List<Task<Sprite>>();
        
        foreach (var location in locations)
            tasks.Add(Addressables.LoadAssetAsync<Sprite>(location).Task);
       
        var loadedSprites = await Task.WhenAll(tasks);
        foreach (var sprite in loadedSprites)
            AllSprites.Add(sprite.name, sprite);
    }
    public Sprite GetSpriteByName(string name_)
    {
        Sprite sprite = null;
        AllSprites.TryGetValue(name_, out sprite);
        if (sprite == null)
            Debug.Log($"null: {sprite}");
        return sprite;
    }
}

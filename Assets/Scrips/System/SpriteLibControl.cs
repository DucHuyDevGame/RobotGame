using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;

public class SpriteLibControl : BYSingletonMono<SpriteLibControl>
{
    public static readonly Dictionary<string, Sprite> AllSprites = new Dictionary<string, Sprite>();
    
    public Sprite GetSpriteByName(string name_)
    {
        Sprite sprite = null;
        AllSprites.TryGetValue(name_, out sprite);
        if (sprite == null)
            Debug.Log($"null: {sprite}");
        return sprite;
    }
}

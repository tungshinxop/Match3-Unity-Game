using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;


[CreateAssetMenu(menuName = "Scriptable Objects/Item Skin Data", fileName = "Item Skin Data")]
public class ItemSkinData : ScriptableObject
{
    [SerializeField] private SpriteAtlas atlas;
    [SerializeField] private eItemType itemType;
    public Sprite GetSprite(int spriteId)
    {
        return atlas.GetSprite($"{itemType.ToString()}_{spriteId}");
    }
}

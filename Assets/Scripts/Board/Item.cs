using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using ToolBox.Pools;


[Serializable]
public class Item
{
    private SpriteRenderer _cachedSpriteRenderer;
    private SpriteRenderer _cachedItemPrefab;
    
    protected ItemSkinData SkinData { get; private set; }
    
    public Cell Cell { get; private set; }

    public Transform View { get; private set; }
    
    public virtual void SetView()
    {
        var itemSprite = GetSprite();

        if (itemSprite != null)
        {
            if (_cachedItemPrefab == null)
            {
                _cachedItemPrefab = Resources.Load<SpriteRenderer>("prefabs/itemView");
            }

            var item = GameObject.Instantiate(_cachedItemPrefab);
            _cachedSpriteRenderer = item;
            _cachedSpriteRenderer.sprite = itemSprite;
            View = _cachedSpriteRenderer.transform;
        }
    }

    protected virtual Sprite GetSprite() { return null; }

    public void SetSkinData(ItemSkinData skinData)
    {
        SkinData = skinData;
    }
    
    public virtual void SetCell(Cell cell)
    {
        Cell = cell;
    }

    internal void AnimationMoveToPosition()
    {
        if (View == null) return;

        View.DOMove(Cell.transform.position, 0.2f);
    }

    public void SetViewPosition(Vector3 pos)
    {
        if (View)
        {
            View.position = pos;
        }
    }

    public void SetViewRoot(Transform root)
    {
        if (View)
        {
            View.SetParent(root);
        }
    }

    public void SetSortingLayerHigher()
    {
        if (View == null) return;
        
        if (_cachedSpriteRenderer)
        {
            _cachedSpriteRenderer.sortingOrder = 1;
        }
    }


    public void SetSortingLayerLower()
    {
        if (View == null) return;
        
        if (_cachedSpriteRenderer)
        {
            _cachedSpriteRenderer.sortingOrder = 0;
        }
    }

    internal void ShowAppearAnimation()
    {
        if (View == null) return;

        Vector3 scale = View.localScale;
        View.localScale = Vector3.one * 0.1f;
        View.DOScale(scale, 0.1f);
    }

    internal virtual bool IsSameType(Item other)
    {
        return false;
    }

    internal virtual void ExplodeView()
    {
        if (View)
        {
            View.DOScale(0.1f, 0.1f).OnComplete(
                () =>
                {
                    GameObject.Destroy(View.gameObject);
                    View = null;
                }
                );
        }
    }



    internal void AnimateForHint()
    {
        if (View)
        {
            View.DOPunchScale(View.localScale * 0.1f, 0.1f).SetLoops(-1);
        }
    }

    internal void StopAnimateForHint()
    {
        if (View)
        {
            View.DOKill();
        }
    }

    internal void Clear()
    {
        Cell = null;

        if (View)
        {
            GameObject.Destroy(View.gameObject);
            View = null;
        }
    }
}
